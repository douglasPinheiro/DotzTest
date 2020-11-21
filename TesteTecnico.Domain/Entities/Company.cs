using System.Collections.Generic;

namespace TesteTecnico.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        
        public string CNPJ { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Transaction> TransictionsHistory { get; set; }
    }
}