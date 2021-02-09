using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Model;
using TestTask_AS_PetrovGN.Models;
using TestTask_AS_PetrovGN.Services;
using TestTask_AS_PetrovGN.ViewModels;

namespace TestTask_AS_PetrovGN.Controllers
{
    public class ApiOrganizationController: ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly OrgDbContext db;
        public ApiOrganizationController(IEmployeeService _employeeService, OrgDbContext _db)
        {
            employeeService = _employeeService;
            db = _db;
        }


        public async Task CreateTestData()
        {
            await employeeService.AddTestData();
        }

        public async Task<List<DepartmentVM>> GetAllDepartments()
        {
            try
            {
                return await db.Departments.Include(e => e.Employees).Select(e => new DepartmentVM
                {
                    Employees = e.Employees,
                    Id = e.Id,
                    Title = e.Title,
                    MidSalary = e.Employees.Any() ? e.Employees.Average(x => x.Salary) : 0,
                    EmployeeCount = e.Employees.Count()
                }).ToListAsync();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("w");
                return null;
            }
        }

        public async Task<StatusCodeResult> AddEmployee(Employee employee)
        {
            await employeeService.Addemployee(employee);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index", "Organization");
        }

        public async Task<StatusCodeResult> DeleteEmployee(int id)
        {
            await employeeService.DeleteEmployee(id);
            return Ok();
        }

        public async Task<bool> CheckDb()
        {
            var weHave = await db.Departments.AnyAsync();
            if (!weHave) throw new Exception("Нет записей в БД");
            return weHave;
        }

        public async Task AddNewData()
        {
            await employeeService.AddTestData();
        }
    }
}
