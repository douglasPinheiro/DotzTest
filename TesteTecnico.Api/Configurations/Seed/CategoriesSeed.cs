using System.Collections.Generic;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Api.Configurations.Seed
{
    public class CategoriesSeed
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category { Id = 1, Name = "Informatica" },
                new Category { Id = 2, Name = "Esporte" },
                new Category { Id = 3, Name = "Moveis" },
                new Category { Id = 4, Name = "Moda" }
            };
        }

        public IEnumerable<SubCategory> GetSubCategories()
        {
            return new List<SubCategory>()
            {
                // Informatica
                new SubCategory { Id = 1, Name = "Notebook", Category = new Category { Id = 1 } },
                new SubCategory { Id = 2, Name = "Tablet", Category = new Category { Id = 1 }  },
                new SubCategory { Id = 3, Name = "Computador", Category = new Category { Id = 1 }  },
                new SubCategory { Id = 4, Name = "Impressora", Category = new Category { Id = 1 }  },
                // Esporte
                new SubCategory { Id = 5, Name = "Bicicleta", Category = new Category { Id = 2 } },
                new SubCategory { Id = 6, Name = "Esteira", Category = new Category { Id = 2 } },
                new SubCategory { Id = 7, Name = "Piscina Inflável", Category = new Category { Id = 2 } },
                // Moveis
                new SubCategory { Id = 8, Name = "Guarda Roupa", Category = new Category { Id = 3 } },
                new SubCategory { Id = 9, Name = "Cama", Category = new Category { Id = 3 } },
                new SubCategory { Id = 10, Name = "Sofá", Category = new Category { Id = 3 } },
                // Moda
                new SubCategory { Id = 11, Name = "Tenis", Category = new Category { Id = 4 } },
                new SubCategory { Id = 12, Name = "Bota", Category = new Category { Id = 4 } },
                new SubCategory { Id = 13, Name = "Sapato", Category = new Category { Id = 4 } }
            };
        }
    }
}
