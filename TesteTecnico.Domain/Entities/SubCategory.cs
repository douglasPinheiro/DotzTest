using System.Collections.Generic;

namespace TesteTecnico.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}