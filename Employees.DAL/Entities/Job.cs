using Employees.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Entities
{
    public class Job : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Job()
        {
            Employees = new List<Employee>();
        }
    }
}
