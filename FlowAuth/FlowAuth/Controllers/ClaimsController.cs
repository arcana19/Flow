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
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public ClaimsController(ApplicationDbContext context ,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: Claims
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var claims = from c in _context.Claims.Include(c => c.AppUser).Include(c => c.Staff)
                         select c ;

            claims = claims.Where(m => m.StaffID.Equals(user.StaffID));

            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                claims = claims.Where(c => c.Staff.Staff_fullName.Contains(searchString)
                    || c.AppUser.Staff.Staff_fullName.Contains(searchString));
            }

            return View(await claims.ToListAsync());
        }

        //GET: All the claims
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> All(string sortOrder, string searchString)
        {
            var claims = from c in _context.Claims.Include(c => c.AppUser).Include(c => c.Staff)
                         select c; ;


            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                claims = claims.Where(c => c.Staff.Staff_fullName.Contains(searchString)
                    || c.AppUser.Staff.Staff_fullName.Contains(searchString));
            }

            return View(await claims.ToListAsync());
        }

        // GET: Claims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.AppUser)
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(m => m.ClaimID == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // GET: Claims/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName");
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimID,Claim_amount,Claim_description,Claim_status,Claim_date,StaffID,UserId")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", claim.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", claim.StaffID);
            return View(claim);
        }

        // GET: Claims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", claim.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", claim.StaffID);
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimID,Claim_amount,Claim_description,Claim_status,Claim_date,StaffID,UserId")] Claim claim)
        {
            if (id != claim.ClaimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.ClaimID))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", claim.UserId);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "Staff_fullName", claim.StaffID);
            return View(claim);
        }

        // GET: Claims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.AppUser)
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(m => m.ClaimID == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimExists(int id)
        {
            return _context.Claims.Any(e => e.ClaimID == id);
        }
    }
}
