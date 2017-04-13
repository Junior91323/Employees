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
    public class EmployeesController : ApiController
    {

        IEmployeesService EmployeeService;
        public EmployeesController(IEmployeesService service)
        {
            EmployeeService = service;
        }

        // GET api/values
        public IEnumerable<EmployeeViewModel> Get()
        {
            IEnumerable<EmployeeDTO> employeesDto = EmployeeService.GetEmployees();
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>());
            var items = Mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeesDto);
            return items;
        }

        // GET api/values/5
        public EmployeeViewModel Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>());
            var item = Mapper.Map<EmployeeDTO, EmployeeViewModel>(EmployeeService.GetEmployee(id));
            return item;
        }

        // POST api/values
        public void Post([FromBody]EmployeeViewModel value)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeViewModel, EmployeeDTO>());
            var item = Mapper.Map<EmployeeViewModel, EmployeeDTO>(value);
            EmployeeService.CreateEmployee(item);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            EmployeeService.DeleteEmployee(id);
        }
    }
}
