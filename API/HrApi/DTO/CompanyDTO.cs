using HrApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.DTO
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Founded { get; set; }
        public Image Image { get; set; }
    }
}
