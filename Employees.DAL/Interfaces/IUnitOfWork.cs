using Employees.DAL.Entities;
using Employees.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository Employees { get; }
        IJobsRepository Jobs { get; }
        void Save();
    }
}
