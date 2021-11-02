using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Pagination
{
    public class CompanyParameters : QueryStringParameters
    {
        public CompanyParameters()
        {
            OrderBy = "name";
        }
        public uint MinFounded { get; set; }
        public uint MaxFounded { get; set; } = (uint)DateTime.Now.Year;
        public bool ValidYearRange => MaxFounded > MinFounded;

        public string Name { get; set; }
    }
}
