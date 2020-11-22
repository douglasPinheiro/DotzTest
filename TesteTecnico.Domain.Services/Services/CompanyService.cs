using System;
using System.Collections.Generic;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Company company)
        {
            company.CreatedAt = DateTime.Now;
            _unitOfWork.Adresses.Add(company.Address);
            _unitOfWork.Companies.Add(company);
            _unitOfWork.SaveChanges();
        }

        public Company GetById(int id)
        {
            return _unitOfWork.Companies.GetById(id);
        }

        public IEnumerable<Company> List()
        {
            return _unitOfWork.Companies.List();
        }

        public int Count()
        {
            return _unitOfWork.Companies.Count();
        }
    }
}
