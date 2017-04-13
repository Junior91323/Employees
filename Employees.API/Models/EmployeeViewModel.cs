using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.API.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Rate { get; set; }

        public int JobId { get; set; }
        public string JobTitle { get; set; }
    }
}