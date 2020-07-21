using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowAuth.Data;
using FlowAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace FlowAuth.Controllers
{
    [Authorize]
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MyProjects(int id)
        {
            return View();
        }

        // GET: Staffs
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //This where we specify the sortOrder parameters... "lname_desc" is used for sorting the staff by last name
            ViewBag.FullNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var staffs = from s in _context.Staffs
                         select s;

            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(s => s.Staff_fullName.Contains(searchString));

            }

            //to check if there is a specified sort order
            switch (sortOrder)
            {
                case "name_desc":
                    staffs = staffs.OrderByDescending(s => s.Staff_fullName);
                    break;
                default:
                    staffs = staffs.OrderBy(s => s.Staff_fullName);
                    break;
            }

            return View(await staffs.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        [Authorize(Roles ="Admin,Management")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> Create([Bind("StaffID,Staff_type,Staff_fullName,Staff_position,Staff_emp_nature,Staff_res_addr,Staff_cellphone,Staff_email,Staff_DOB,Staff_country,Staff_idNum,Staff_passport,Staff_incomeTax,Staff_medicalAid,Staff_medicalAidNo,Staff_nextKin_name,Staff_nextKin_cellphone,Staff_rate,Staff_leaveDays,Staff_lastDay")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,Staff_type,Staff_fullName,Staff_position,Staff_emp_nature,Staff_res_addr,Staff_cellphone,Staff_email,Staff_DOB,Staff_country,Staff_idNum,Staff_passport,Staff_incomeTax,Staff_medicalAid,Staff_medicalAidNo,Staff_nextKin_name,Staff_nextKin_cellphone,Staff_rate,Staff_leaveDays,Staff_lastDay")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            return View(staff);
        }

        // GET: Staffs/Delete/5
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Management")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffID == id);
        }
    }
}
