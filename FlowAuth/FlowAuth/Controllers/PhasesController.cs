using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowAuth.Data;
using FlowAuth.Models;

namespace FlowAuth.Controllers
{
    public class PhasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phases.Include(p => p.PhaseName).Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Phases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .Include(p => p.PhaseName)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.PhaseID == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // GET: Phases/Create
        public IActionResult Create()
        {
            ViewData["PhaseNameID"] = new SelectList(_context.PhaseNames, "PhaseNameID", "Phase_name");
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code");
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhaseID,PhaseNameID,Project_Code,Phase_startDate,Phase_endDate,Phase_budget")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhaseNameID"] = new SelectList(_context.PhaseNames, "PhaseNameID", "Phase_name", phase.PhaseNameID);
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", phase.Project_Code);
            return View(phase);
        }

        // GET: Phases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }
            ViewData["PhaseNameID"] = new SelectList(_context.PhaseNames, "PhaseNameID", "Phase_name", phase.PhaseNameID);
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", phase.Project_Code);
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhaseID,PhaseNameID,Project_Code,Phase_startDate,Phase_endDate,Phase_budget")] Phase phase)
        {
            if (id != phase.PhaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.PhaseID))
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
            ViewData["PhaseNameID"] = new SelectList(_context.PhaseNames, "PhaseNameID", "Phase_name", phase.PhaseNameID);
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", phase.Project_Code);
            return View(phase);
        }

        // GET: Phases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phase = await _context.Phases
                .Include(p => p.PhaseName)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.PhaseID == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            _context.Phases.Remove(phase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.PhaseID == id);
        }
    }
}
