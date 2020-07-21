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
    [Authorize(Roles = "Admin,Management")]
    public class SuppliedByController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliedByController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuppliedBy
        public async Task<IActionResult> Index(string searchString)
        {
            var suppliedBies = from sb in _context.SuppliedBys.Include(s => s.Project).Include(s => s.Supplier)
                               select sb;

            if (!String.IsNullOrEmpty(searchString))
            {
                suppliedBies = suppliedBies.Where(sb => sb.Supplier.Supplier_name.Contains(searchString)
                                                    || sb.Project_Code.Contains(searchString));
            }
            return View(await suppliedBies.ToListAsync());
        }

        // GET: SuppliedBy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliedBy = await _context.SuppliedBys
                .Include(s => s.Project)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SuppliedByID == id);
            if (suppliedBy == null)
            {
                return NotFound();
            }

            return View(suppliedBy);
        }

        // GET: SuppliedBy/Create
        public IActionResult Create()
        {
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Supplier_name");
            return View();
        }

        // POST: SuppliedBy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuppliedByID,SupplierID,Project_Code")] SuppliedBy suppliedBy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suppliedBy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", suppliedBy.Project_Code);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Supplier_name", suppliedBy.SupplierID);
            return View(suppliedBy);
        }

        // GET: SuppliedBy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliedBy = await _context.SuppliedBys.FindAsync(id);
            if (suppliedBy == null)
            {
                return NotFound();
            }
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", suppliedBy.Project_Code);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Supplier_name", suppliedBy.SupplierID);
            return View(suppliedBy);
        }

        // POST: SuppliedBy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuppliedByID,SupplierID,Project_Code")] SuppliedBy suppliedBy)
        {
            if (id != suppliedBy.SuppliedByID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suppliedBy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliedByExists(suppliedBy.SuppliedByID))
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
            ViewData["Project_Code"] = new SelectList(_context.Projects, "Project_Code", "Project_Code", suppliedBy.Project_Code);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Supplier_name", suppliedBy.SupplierID);
            return View(suppliedBy);
        }

        // GET: SuppliedBy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliedBy = await _context.SuppliedBys
                .Include(s => s.Project)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SuppliedByID == id);
            if (suppliedBy == null)
            {
                return NotFound();
            }

            return View(suppliedBy);
        }

        // POST: SuppliedBy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suppliedBy = await _context.SuppliedBys.FindAsync(id);
            _context.SuppliedBys.Remove(suppliedBy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliedByExists(int id)
        {
            return _context.SuppliedBys.Any(e => e.SuppliedByID == id);
        }
    }
}
