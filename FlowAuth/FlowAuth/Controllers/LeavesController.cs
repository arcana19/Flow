using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowAuth.Data;
using FlowAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FlowAuth.Controllers
{
    [Authorize]
    public class LeavesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public LeavesController(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        //show leaves for all the users
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> All(string sortOrder, string searchString)
        {
            //sorting thins out by staff name,approver name, leave start and end date
            ViewBag.StaffNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.ApproverNameSortParm = String.IsNullOrEmpty(sortOrder) ? "approver_desc" : "approver";
            ViewBag.StartDateSortParm = sortOrder == "startDate" ? "startDate_desc" : "startDate";
            ViewBag.EndDateSortParm = sortOrder == "endDate" ? "endDate_desc" : "endDate";

            var leaves = from l in _context.Leaves.Include(l => l.AppUser).Include(l => l.Staff)
                         select l;

            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                leaves = leaves.Where(c => c.Staff.Staff_fullName.Contains(searchString));
            }

            //the sorting happens here
            switch (sortOrder)
            {
                case "name_desc":
                    leaves = leaves.OrderByDescending(l => l.Staff.Staff_fullName);
                    break;
                case "name":
                    leaves = leaves.OrderBy(l => l.Staff.Staff_fullName);
                    break;
                case "approver_desc":
                    leaves = leaves.OrderByDescending(l => l.AppUser.Staff.Staff_fullName);
                    break;
                case "startDate_desc":
                    leaves = leaves.OrderByDescending(l => l.Leave_startDate);
                    break;
                case "startDate":
                    leaves = leaves.OrderBy(l => l.Leave_startDate);
                    break;
                case "endDate_desc":
                    leaves = leaves.OrderByDescending(l => l.Leave_endDate);
                    break;
                case "endDate":
                    leaves = leaves.OrderBy(l => l.Leave_endDate);
                    break;
                default:
                    leaves = leaves.OrderBy(l => l.AppUser.Staff.Staff_fullName);
                    break;
            }
            return View(await leaves.ToListAsync());
        }

        // GET: Leaves
        //show leaves for the current user
        public async Task<IActionResult> Index(string sortOrder,string searchString)
        {
            //sorting thins out by staff name,approver name, leave start and end date
            ViewBag.StaffNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.ApproverNameSortParm = String.IsNullOrEmpty(sortOrder) ? "approver_desc" : "approver";
            ViewBag.StartDateSortParm = sortOrder == "startDate" ? "startDate_desc" : "startDate";
            ViewBag.EndDateSortParm = sortOrder == "endDate" ? "endDate_desc" : "endDate";

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var leaves = from l in _context.Leaves.Include(l => l.AppUser).Include(l => l.Staff)
                         select l;

            //Return leaves for a specific user
            leaves = leaves.Where(l => l.StaffID.Equals(user.StaffID));

            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                leaves = leaves.Where(c => c.Staff.Staff_fullName.Contains(searchString)
                    || c.AppUser.Staff.Staff_fullName.Contains(searchString));
            }

            //the sorting happens here
            switch (sortOrder)
            {
                case "name_desc":
                    leaves = leaves.OrderByDescending(l => l.Staff.Staff_fullName);
                    break;
                case "name":
                    leaves = leaves.OrderBy(l => l.Staff.Staff_fullName);
                    break;
                case "approver_desc":
                    leaves = leaves.OrderByDescending(l => l.AppUser.Staff.Staff_fullName);
                    break;
                case "startDate_desc":
                    leaves = leaves.OrderByDescending(l => l.Leave_startDate);
                    break;
                case "startDate":
                    leaves = leaves.OrderBy(l => l.Leave_startDate);
                    break;
                case "endDate_desc":
                    leaves = leaves.OrderByDescending(l => l.Leave_endDate);
                    break;
                case "endDate":
                    leaves = leaves.OrderBy(l => l.Leave_endDate);
                    break;
                default:
                    leaves = leaves.OrderBy(l => l.AppUser.Staff.Staff_fullName);
                    break;
            }

            return View(await leaves.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves
                .Include(l => l.AppUser)
                .Include(l => l.Staff)
                .FirstOrDefaultAsync(m => m.LeaveID == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // GET: Leaves/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //var userID = await _context.Staffs.FirstOrDefaultAsync(s => s.StaffID == id);

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveID,Leave_type,Leave_days_taken,Leave_startDate,Leave_endDate,Leave_motivation,Leave_status,StaffID,UserId")] Leave leave)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(leave);
                await _context.SaveChangesAsync();
                LeaveDays(leave);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", leave.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", leave.StaffID);
            return View(leave);
        }

        [HttpPost]
        private async void LeaveDays(Leave leave)
        {
            var member = from s in _context.Staffs.AsNoTracking().Where(s => s.StaffID.Equals(leave.StaffID))
                         select s;

            //returns for the specific user

            var JSON = JsonConvert.SerializeObject(member);
            List<Staff> data = JsonConvert.DeserializeObject<List<Staff>>(JSON);

            Staff staff = new Staff();
            if (data.Count() == 1)      //staff is found
            {
                staff = (Staff)data[0];
                staff.Staff_leaveDays = staff.Staff_leaveDays - leave.Leave_days_taken;
                try
                {
                    _context.Staffs.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
                    {
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            
        }
        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", leave.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", leave.StaffID);
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveID,Leave_type,Leave_days_taken,Leave_startDate,Leave_endDate,Leave_motivation,Leave_status,StaffID,UserId")] Leave leave)
        {
            if (id != leave.LeaveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveExists(leave.LeaveID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", leave.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", leave.StaffID);
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves
                .Include(l => l.AppUser)
                .Include(l => l.Staff)
                .FirstOrDefaultAsync(m => m.LeaveID == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(e => e.LeaveID == id);
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffID == id);
        }
    }
}
