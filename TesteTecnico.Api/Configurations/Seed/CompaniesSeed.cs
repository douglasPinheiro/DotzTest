using System.Collections.Generic;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Api.Configurations.Seed
{
    public class CompaniesSeed
    {
        public IEnumerable<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company {
                    Id = 1,
                    CNPJ="49.223.939/0001-04",
                    Name="Company Test 1",
                    Address = new Address {
                        City = "SP",
                        IsActive = true,
                        Number = 12,
                        Neighborhood = "Paulista",
                        PostalCode = "32165-659",
                        State = "SP",
                        Street = "Rua alguma coisa"
                    }
                },
                new Company {
                    Id = 2,
                    CNPJ="02.260.487/0001-77",
                    Name="Company Test 2",
                    Address = new Address {
                        City = "SP",
                        IsActive = true,
                        Number = 13,
                        Neighborhood = "Paulista",
                        PostalCode = "65487-986",
                        State = "SP",
                        Street = "Rua foo bar"
                    }
                }
            };
        }
    }
}
