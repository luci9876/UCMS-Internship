﻿using HrApi.Models;
using HrApi.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Services.Interfaces
{
    public interface ICompanyService
    {
        bool AddCompany(Company company);
        Company GetCompany(int id);
        Company PutCompany(int id, Company company);
        IEnumerable<Company> GetCompanies(CompanyParameters companyParameters);
        bool DeleteCompany(int id);
    }
}