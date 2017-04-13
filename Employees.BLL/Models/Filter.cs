using Employees.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Models
{
    public class Filter : IFilter
    {
        public int Count { get; set; }

        public string Direction { get; set; }

        public string Field { get; set; }

        public int Page { get; set; }
    }
}
