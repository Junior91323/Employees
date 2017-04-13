using Employees.DAL.Interfaces;
using Employees.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string ConnectionString;
        public ServiceModule(string connection)
        {
            ConnectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(ConnectionString);
        }
    }
}
