using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask_AS_PetrovGN.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
