using Employees.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Interfaces
{
    public interface IEmployeesService
    {
        void CreateEmployee(EmployeeDTO item);
        EmployeeDTO GetEmployee(int id);
        void DeleteEmployee(int id);
        IEnumerable<EmployeeDTO> GetEmployees();
        IEnumerable<EmployeeDTO> GetEmployees(IFilter filter);
        void Dispose();
    }
}
