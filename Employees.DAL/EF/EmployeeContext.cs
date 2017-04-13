using Employees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.EF
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public EmployeeContext(string connectionString)
            : base(connectionString)
        {
        }
        public EmployeeContext() : base("DefaultConnection")
        {

        }
        
    }
}
