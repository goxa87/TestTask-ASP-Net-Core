using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Model;

namespace TestTask_AS_PetrovGN.Services
{
    public interface IEmployeeService
    {
        Task AddTestData();
        Task<Employee> Addemployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
