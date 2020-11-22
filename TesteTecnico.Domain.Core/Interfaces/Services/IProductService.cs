using System.Collections.Generic;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface IProductService
    {
        void Create(Product product);

        Product GetById(int id);

        IEnumerable<Product> List();

        int Count();
    }
}
