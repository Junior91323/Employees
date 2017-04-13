using Employees.DAL.EF;
using Employees.DAL.Entities;
using Employees.DAL.Interfaces;
using Employees.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private EmployeeContext db;

        public EmployeesRepository(EmployeeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }
        public IEnumerable<Employee> GetAllWithMembers()
        {
            return db.Employees.Include(x=>x.Job);
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee item)
        {
            if (item != null)
                db.Employees.Add(item);
        }

        public void Update(Employee item)
        {
            if (item != null)
                db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            if (predicate != null)
                return db.Employees.Where(predicate).ToList();

            return db.Employees;
        }

        public void Delete(int id)
        {
            Employee item = db.Employees.Find(id);
            if (item != null)
                db.Employees.Remove(item);
        }
    }
}
