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
    [Authorize(Roles ="Admin,Management")]
    public class AssignedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assigneds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assigneds.Include(a => a.Project).Include(a => a.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assigneds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assigned = await _context.Assigneds
                .Include(a => a.Project)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.AssignedID == id);
            if (assigned == null)
            {
                return NotFound();
            }

            return View(assigned);
        }

        // GET: Assigneds/Create
        public IActionResult Create()
        {
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");
            return View();
        }

        // POST: Assigneds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignedID,StaffID,Project_Code")] Assigned assigned)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assigned);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", assigned.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", assigned.StaffID);
            return View(assigned);
        }

        // GET: Assigneds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assigned = await _context.Assigneds.FindAsync(id);
            if (assigned == null)
            {
                return NotFound();
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", assigned.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", assigned.StaffID);
            return View(assigned);
        }

        // POST: Assigneds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignedID,StaffID,Project_Code")] Assigned assigned)
        {
            if (id != assigned.AssignedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assigned);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedExists(assigned.AssignedID))
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
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", assigned.Project_Code);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", assigned.StaffID);
            return View(assigned);
        }

        // GET: Assigneds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assigned = await _context.Assigneds
                .Include(a => a.Project)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.AssignedID == id);
            if (assigned == null)
            {
                return NotFound();
            }

            return View(assigned);
        }

        // POST: Assigneds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assigned = await _context.Assigneds.FindAsync(id);
            _context.Assigneds.Remove(assigned);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignedExists(int id)
        {
            return _context.Assigneds.Any(e => e.AssignedID == id);
        }
    }
}
