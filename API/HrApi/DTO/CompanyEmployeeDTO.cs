using HrApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.DTO
{
    public class CompanyEmployeeDTO
    {
        public Company Company { get; set; }
        public Employee Employee { get; set; }
    }
}
