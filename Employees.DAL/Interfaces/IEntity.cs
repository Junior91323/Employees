﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
