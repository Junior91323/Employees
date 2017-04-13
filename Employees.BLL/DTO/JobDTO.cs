﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.DTO
{
   public class JobDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}