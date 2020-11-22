using System;
using System.Collections.Generic;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Count()
        {
            return _unitOfWork.Products.Count();
        }

        public void Create(Product product)
        {
            product.IsActive = true;
            product.CreatedAt = DateTime.Now;
            _unitOfWork.Products.Add(product);
            _unitOfWork.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public IEnumerable<Product> List()
        {
            return _unitOfWork.Products.List();
        }
    }
}
