using HrApi.Data.Models.Helpers.Interfaces;
using HrApi.Data.Models.Interfaces;
using HrApi.Data.Repositories.Interfaces;
using HrApi.Models;
using HrApi.Repositories;
using HrApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApi.Data.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private HrContext _hrContext;
		private ICompanyRepository _company;
		private ISortHelper<Company> _companySortHelper;
		private IDataShaper<Company> _companyDataShaper;


		public ICompanyRepository Company
		{
			get
			{
				if (_company == null)
				{
					_company = new CompanyRepository(_hrContext, _companySortHelper, _companyDataShaper);
				}

				return _company;
			}
		}

        public RepositoryWrapper(HrContext HRContext,ISortHelper<Company> companySortHelper, IDataShaper<Company> companyDataShaper)
		{
			_hrContext = HRContext;
			_companySortHelper = companySortHelper;
			_companyDataShaper = companyDataShaper;
		}

		public void Save()
		{
			_hrContext.SaveChanges();
		}
	}
}
