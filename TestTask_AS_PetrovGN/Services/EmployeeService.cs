using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Model;
using TestTask_AS_PetrovGN.Models;

namespace TestTask_AS_PetrovGN.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly OrgDbContext db;
        public EmployeeService(OrgDbContext _db)
        {
            db = _db;
        }

        

        public async Task<Employee> Addemployee(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task AddTestData()
        {
            var depsList = new List<Department>()
            {
                new Department()
                {
                    Title = "Департмент 1",
                    Employees = new List<Employee>(){
                        new Employee(){ Name = "Вася", Salary =10000 },
                        new Employee(){ Name = "Петя", Salary =20000 },
                        new Employee(){ Name = "Маша", Salary =30000 },
                        new Employee(){ Name = "Саша", Salary =40000 },
                    }
                },

                new Department()
                {
                    Title = "Департмент 2",
                    Employees = new List<Employee>(){
                        new Employee(){ Name = "Витя", Salary =50000 },
                        new Employee(){ Name = "Вася", Salary =60000 },
                        new Employee(){ Name = "Коля", Salary =70000 },
                        new Employee(){ Name = "Мария", Salary =10000 },
                    }
                },
                new Department()
                {
                    Title = "Департмент 3",
                    Employees = new List<Employee>(){
                        new Employee(){ Name = "Рузанна", Salary =10000 },
                        new Employee(){ Name = "Снежанна", Salary =20000 },
                        new Employee(){ Name = "Гюльчитай", Salary =30000 },
                        new Employee(){ Name = "Шаганэ", Salary =40000 },
                    }
                },
                new Department()
                {
                    Title = "Департмент 4",
                    Employees = new List<Employee>(){
                        new Employee(){ Name = "Марк Аврелий", Salary =50000 },
                        new Employee(){ Name = "Гай Юлий", Salary =60000 },
                        new Employee(){ Name = "Калигула", Salary =70000 },
                        new Employee(){ Name = "Октавиан Август", Salary =20000 },
                    }
                },
            };

            db.Departments.AddRange(depsList);
            await db.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var emp = await db.Employees.FirstAsync(e => e.Id == id);
            db.Employees.Remove(emp);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
        }
    }
}
