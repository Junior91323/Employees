using Employees.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Rate { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
