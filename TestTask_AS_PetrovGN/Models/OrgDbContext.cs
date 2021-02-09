using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask_AS_PetrovGN.Model;

namespace TestTask_AS_PetrovGN.Models
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext(DbContextOptions<OrgDbContext> optionsBuilder): base(optionsBuilder)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
