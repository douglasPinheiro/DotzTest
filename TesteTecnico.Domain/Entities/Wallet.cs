using System.Collections.Generic;

namespace TesteTecnico.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public decimal DotzBalance { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<Transaction> TransactionsHistory { get; set; }

        //public virtual ICollection<Order> DeliveryHistory { get; set; }
    }
}
