using Employees.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.BLL.DTO;
using Employees.DAL.Interfaces;
using Employees.DAL.Entities;
using AutoMapper;

namespace Employees.BLL.Services
{
    public class EmployeesService : IEmployeesService
    {
        IUnitOfWork DB { get; set; }

        public EmployeesService(IUnitOfWork uow)
        {
            DB = uow;
        }
        public void CreateEmployee(EmployeeDTO item)
        {
            try
            {
                if (item == null)
                    throw new NullReferenceException("item is null");

                Employee employee = DB.Employees.Get(item.Id);

                if (employee != null)
                    throw new Exception("Employee already exist");

                Employee res = new Employee
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    CreatedDate = DateTime.Now,
                    EmploymentDate = item.EmploymentDate,
                    JobId = item.JobId,
                    Rate = item.Rate
                };
                DB.Employees.Create(res);
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

        public EmployeeDTO GetEmployee(int id)
        {
            try
            {
                var item = DB.Employees.Get(id);

                if (item == null)
                    throw new NullReferenceException(String.Format("Item with id: {0} is not found!", id));

                Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>().ForMember("JobTitle", opt => opt.MapFrom(c => c.Job.Title)));
                return Mapper.Map<Employee, EmployeeDTO>(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>().ForMember("JobTitle", opt => opt.MapFrom(c => c.Job.Title)));
            return Mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(DB.Employees.GetAllWithMembers().OrderByDescending(x=>x.CreatedDate));
        }

        public IEnumerable<EmployeeDTO> GetEmployees(IFilter filter)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>().ForMember("JobTitle", opt => opt.MapFrom(c => c.Job.Title)));
                IEnumerable<Employee> res = DB.Employees.GetAllWithMembers().OrderByDescending(x => x.CreatedDate);
                if (filter != null)
                {
                    res = res.Skip((filter.Page - 1) * filter.Count).Take(filter.Count);
                }

                return Mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee item = DB.Employees.Get(id);

                if (item == null)
                    throw new NullReferenceException(String.Format("Item with id: {0} is not found!", id));

                DB.Employees.Delete(id);
                DB.Save();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
