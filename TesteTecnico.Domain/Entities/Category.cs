using System.Collections.Generic;

namespace TesteTecnico.Domain.Entities
{
    public class Category
    {
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}