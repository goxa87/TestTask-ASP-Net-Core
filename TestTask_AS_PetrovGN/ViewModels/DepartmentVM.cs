using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Model;

namespace TestTask_AS_PetrovGN.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
        public int EmployeeCount {get; set;}
        public double MidSalary { get; set; }

    }
}
