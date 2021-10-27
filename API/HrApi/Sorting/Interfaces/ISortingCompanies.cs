using HrApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Sorting.Interfaces
{
   public interface ISortingCompanies
    {
        void ApplySort(ref IQueryable<Company> companies, string orderByQueryString);
        void SearchByName(ref IQueryable<Company> companies, string companyName);
    }
}
