using AutoMapper;
using Employees.API.Models;
using Employees.BLL.DTO;
using Employees.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.API.Controllers
{
    public class JobsController : ApiController
    {
        IJobsService JobsService;
        public JobsController(IJobsService service)
        {
            JobsService = service;
        }
        // GET: api/Jobs
        public IEnumerable<JobViewModel> Get()
        {
            IEnumerable<JobDTO> jobsDto = JobsService.GetJobs();
            Mapper.Initialize(cfg => cfg.CreateMap<JobDTO, JobViewModel>());
            var jobs = Mapper.Map<IEnumerable<JobDTO>, List<JobViewModel>>(jobsDto);
            return jobs;
        }

        // GET: api/Jobs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Jobs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Jobs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Jobs/5
        public void Delete(int id)
        {
        }
    }
}
