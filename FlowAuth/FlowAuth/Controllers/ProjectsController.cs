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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //show user profiles they assigned to


        // GET: Projects
        public async Task<IActionResult> Index(string sortOrder,string searchString)
        {
            //sort by client name ,project code and dates
            ViewBag.ClientNameSortParm = String.IsNullOrEmpty(sortOrder) ? "clientName_desc" : "";
            ViewBag.StartDateSortParm = sortOrder == "startDate" ? "startDate_desc" : "startDate";
            ViewBag.EndDateSortParm = sortOrder == "endDate" ? "endDate_desc" : "endDate";
            ViewBag.ProjectCodeSortParm = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "code";

            var projects = from p in _context.Projects.Include(p => p.Client)
                           select p;

            //This where the search actually happens
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.Project_Code.Contains(searchString)
                                        || p.Client.Client_name.Contains(searchString));
            }

            //to check if there is a specified sort order
            switch (sortOrder)
            {
                case "clientName_desc":
                    projects = projects.OrderByDescending(p => p.Client.Client_name);
                    break;
                case "code_desc":
                    projects = projects.OrderByDescending(a => a.Project_Code);
                    break;
                case "code":
                    projects = projects.OrderBy(a => a.Project_Code);
                    break;
                case "startDate_desc":
                    projects = projects.OrderByDescending(p => p.Project_startDate);
                    break;
                case "startDate":
                    projects = projects.OrderBy(p => p.Project_startDate);
                    break;
                case "endDate_desc":
                    projects = projects.OrderByDescending(p => p.Project_endDate);
                    break;
                case "endDate":
                    projects = projects.OrderBy(p => p.Project_endDate);
                    break;
                default:
                    projects = projects.OrderByDescending(p => p.Project_dueDate);
                    break;
            }

            
            return View(await projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Phases)
                .ThenInclude(x => x.PhaseName)
                .FirstOrDefaultAsync(m => m.Project_Code == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles ="Management")]
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Client_name");
            return View();
        }

        [Authorize(Roles ="Management")]
        public IActionResult Assignment()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> Create([Bind("Project_Code,Project_description,Project_location,Project_nature,Project_startDate,Project_dueDate,Project_endDate,Project_budget,Project_status,ClientID")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Client_name", project.ClientID);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Client_name", project.ClientID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> Edit(string id, [Bind("Project_Code,Project_description,Project_location,Project_nature,Project_startDate,Project_dueDate,Project_endDate,Project_budget,Project_status,ClientID")] Project project)
        {
            if (id != project.Project_Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Project_Code))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Client_name", project.ClientID);
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.Project_Code == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(string id)
        {
            return _context.Projects.Any(e => e.Project_Code == id);
        }
    }
}
