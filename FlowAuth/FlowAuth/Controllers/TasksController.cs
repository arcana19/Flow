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
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskDescrptions.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDescription = await _context.TaskDescrptions
                .FirstOrDefaultAsync(m => m.TaskDescriptionID == id);
            if (taskDescription == null)
            {
                return NotFound();
            }

            return View(taskDescription);
        }

        // GET: Tasks/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskDescriptionID,Task_name")] TaskDescription taskDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskDescription);
        }

        // GET: Tasks/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDescription = await _context.TaskDescrptions.FindAsync(id);
            if (taskDescription == null)
            {
                return NotFound();
            }
            return View(taskDescription);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskDescriptionID,Task_name")] TaskDescription taskDescription)
        {
            if (id != taskDescription.TaskDescriptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDescriptionExists(taskDescription.TaskDescriptionID))
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
            return View(taskDescription);
        }

        // GET: Tasks/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDescription = await _context.TaskDescrptions
                .FirstOrDefaultAsync(m => m.TaskDescriptionID == id);
            if (taskDescription == null)
            {
                return NotFound();
            }

            return View(taskDescription);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDescription = await _context.TaskDescrptions.FindAsync(id);
            _context.TaskDescrptions.Remove(taskDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskDescriptionExists(int id)
        {
            return _context.TaskDescrptions.Any(e => e.TaskDescriptionID == id);
        }
    }
}
