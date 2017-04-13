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
    public class JobsRepository : IJobsRepository
    {
        private EmployeeContext db;

        public JobsRepository(EmployeeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Job> GetAll()
        {
            return db.Jobs;
        }

        public Job Get(int id)
        {
            return db.Jobs.Find(id);
        }

        public void Create(Job item)
        {
            if (item != null)
                db.Jobs.Add(item);
        }

        public void Update(Job item)
        {
            if (item != null)
                db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Job> Find(Func<Job, Boolean> predicate)
        {
            if (predicate != null)
                return db.Jobs.Where(predicate).ToList();

            return db.Jobs;
        }

        public void Delete(int id)
        {
            Job item = db.Jobs.Find(id);
            if (item != null)
                db.Jobs.Remove(item);
        }

    }
}
