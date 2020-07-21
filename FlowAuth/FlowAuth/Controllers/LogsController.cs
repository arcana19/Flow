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

namespace FlowAuth.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;


        public LogsController(ApplicationDbContext context,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        //Get:Logs for a user
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //sort by name and date
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            //getting user
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            var logs = from l in _context.Logs.Include(l => l.Project).Include(l => l.Staff).Include(l => l.TaskDescription)
                       select l;

            //Return logs for a specific user
            logs = logs.Where(l => l.StaffID.Equals(user.StaffID));


            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                logs = logs.Where(l => l.Project_Code.Contains(searchString));
            }

            //to check if there is a specified sort order
            switch (sortOrder)
            {
                case "Date_desc":
                    logs = logs.OrderBy(l => l.Log_date);
                    break;
                default:
                    logs = logs.OrderByDescending(l => l.Log_date);
                    break;
            }

            return View(await logs.ToListAsync());
        }

        // GET: Logs
        [Authorize(Roles="Management")]
        public async Task<IActionResult> All(string sortOrder,string searchString)
        {
            //sort by name and date
            ViewBag.StaffNameSortParm = String.IsNullOrEmpty(sortOrder) ? "staffName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            var logs = from l in _context.Logs.Include(l => l.Project).Include(l => l.Staff).Include(l => l.TaskDescription)
                       select l;


            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                logs = logs.Where(l => l.Project_Code.Contains(searchString)
                            || l.Staff.Staff_fullName.Contains(searchString));
            }

            //to check if there is a specified sort order
            switch (sortOrder)
            {
                case "staffName_desc":
                    logs = logs.OrderByDescending(l => l.Staff.Staff_fullName);
                    break;
                case "Date_desc":
                    logs = logs.OrderBy(l => l.Log_date);
                    break;
                default:
                    logs = logs.OrderByDescending(l => l.Log_date);
                    break;
            }

            return View(await logs.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Project)
                .Include(l => l.Staff)
                .Include(l => l.TaskDescription)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");
            ViewData["TaskDescriptionID"] = new SelectList(_context.TaskDescrptions, "TaskDescriptionID", "Task_name");
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,Project_Code,StaffID,TaskDescriptionID,Log_date,Log_hours")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", log.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", log.StaffID);
            ViewData["TaskDescriptionID"] = new SelectList(_context.TaskDescrptions, "TaskDescriptionID", "Task_name", log.TaskDescriptionID);
            return View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", log.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", log.StaffID);
            ViewData["TaskDescriptionID"] = new SelectList(_context.TaskDescrptions, "TaskDescriptionID", "Task_name", log.TaskDescriptionID);
            return View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogID,Project_Code,StaffID,TaskDescriptionID,Log_date,Log_hours")] Log log)
        {
            if (id != log.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.LogID))
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
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", log.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", log.StaffID);
            ViewData["TaskDescriptionID"] = new SelectList(_context.TaskDescrptions, "TaskDescriptionID", "Task_name", log.TaskDescriptionID);
            return View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Project)
                .Include(l => l.Staff)
                .Include(l => l.TaskDescription)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
            return _context.Logs.Any(e => e.LogID == id);
        }
    }
}
