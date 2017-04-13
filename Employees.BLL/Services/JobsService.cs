using Employees.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.BLL.DTO;
using AutoMapper;
using Employees.DAL.Interfaces;
using Employees.DAL.Entities;

namespace Employees.BLL.Services
{
    public class JobsService : IJobsService
    {
        IUnitOfWork DB { get; set; }

        public JobsService(IUnitOfWork uow)
        {
            DB = uow;
        }
        public void CreateJob(JobDTO item)
        {
            try
            {
                if (item == null)
                    throw new NullReferenceException("item is null");

                Job job = DB.Jobs.Get(item.Id);

                if (job != null)
                    throw new Exception("Employee already exist");

                Job res = new Job
                {

                };
                DB.Jobs.Create(res);
                DB.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public JobDTO GetJob(int id)
        {
            try
            {
                var item = DB.Jobs.Get(id);

                if (item == null)
                    throw new NullReferenceException("Item with id: {0} is not found!");

                Mapper.Initialize(cfg => cfg.CreateMap<Job, JobDTO>());
                return Mapper.Map<Job, JobDTO>(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<JobDTO> GetJobs()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Job, JobDTO>());
            return Mapper.Map<IEnumerable<Job>, List<JobDTO>>(DB.Jobs.GetAll());
        }

        public void DeleteJob(int id)
        {
            throw new NotImplementedException();
        }
    }
}
