namespace Employees.DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Employees.DAL.EF.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Employees.DAL.EF.EmployeeContext context)
        {

            //context.Jobs.Add(new Job { CreatedDate = DateTime.Now, Title = "CEO" });
            //context.Jobs.Add(new Job { CreatedDate = DateTime.Now, Title = "Business Analyst" });
            //context.Jobs.Add(new Job { CreatedDate = DateTime.Now, Title = "Developer" });
            //context.Jobs.Add(new Job { CreatedDate = DateTime.Now, Title = "QA" });

        }
    }
}
