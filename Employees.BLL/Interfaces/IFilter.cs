using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Interfaces
{
    public interface IFilter
    {
        int Count { get; set; }
        int Page { get; set; }
        string Field { get; set; }
        string Direction { get; set; }
    }
}
