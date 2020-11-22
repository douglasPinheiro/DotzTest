using System.Collections.Generic;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        void Create(Company company);

        Company GetById(int id);

        IEnumerable<Company> List();

        int Count();
    }
}
