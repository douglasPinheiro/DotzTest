using TesteTecnico.Domain.Enums;

namespace TesteTecnico.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal DotzCost { get; set; }

        public virtual Product Product { get; set; }

        public virtual Company Company { get; set; }

        public virtual Wallet Wallet { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
