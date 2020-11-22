using System.Collections.Generic;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Api.Configurations.Seed
{
    public class ProductsSeed
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Cost = 1000,
                    RewardInDotz = 100,
                    Name="Notebook generico",
                    Company = new Company { Id = 1 },
                    SubCategory = new SubCategory { Id = 1 }
                },
                new Product
                {
                    Id = 2,
                    Cost = 2000,
                    RewardInDotz = 200,
                    Name="Tablet generico",
                    Company = new Company { Id = 1 },
                    SubCategory = new SubCategory { Id = 2 }
                },
                new Product
                {
                    Id = 3,
                    Cost = 3000,
                    RewardInDotz = 300,
                    Name="PC generico",
                    Company = new Company { Id = 1 },
                    SubCategory = new SubCategory { Id = 3 }
                }
            };
        } 
    }
}
