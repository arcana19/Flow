using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlowAuth.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }
        public IActionResult EmployeeSummary()
        {
            return View();
        }
        public IActionResult EmployeeIndividual()
        {
            return View();
        }
    }
}