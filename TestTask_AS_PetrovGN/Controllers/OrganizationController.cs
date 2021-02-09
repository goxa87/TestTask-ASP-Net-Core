using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Models;

namespace TestTask_AS_PetrovGN.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly OrgDbContext db;

        public OrganizationController(ILogger<OrganizationController> logger
            , OrgDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetModal(int empId)
        {
            var emp = await db.Employees.FirstAsync(e => e.Id == empId);
            return PartialView("/Views/Organization/_EmployeeModal.cshtml", emp);
        }
    }
}
