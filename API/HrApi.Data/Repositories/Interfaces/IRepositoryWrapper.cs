using HrApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApi.Data.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        void Save();
    }
}
