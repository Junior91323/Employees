using Employees.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Interfaces.Repositories
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllWithMembers();
    }
}
