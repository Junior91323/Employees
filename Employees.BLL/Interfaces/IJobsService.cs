using Employees.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Interfaces
{
    public interface IJobsService
    {
        void CreateJob(JobDTO item);
        JobDTO GetJob(int id);
        void DeleteJob(int id);
        IEnumerable<JobDTO> GetJobs();
        void Dispose();
    }
}
