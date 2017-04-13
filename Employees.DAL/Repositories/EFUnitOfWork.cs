using Employees.DAL.EF;
using Employees.DAL.Entities;
using Employees.DAL.Interfaces;
using Employees.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EmployeeContext DB;
        private EmployeesRepository employeesRepository;
        private JobsRepository jobsRepository;

        public IEmployeesRepository Employees
        {
            get
            {
                if (employeesRepository == null)
                    employeesRepository = new EmployeesRepository(DB);
                return employeesRepository;
            }
        }
        public IJobsRepository Jobs
        {
            get
            {
                if (jobsRepository == null)
                    jobsRepository = new JobsRepository(DB);
                return jobsRepository;
            }
        }

        public EFUnitOfWork(string connectionString)
        {
            DB = new EmployeeContext(connectionString);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DB.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
