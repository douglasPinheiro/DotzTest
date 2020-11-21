using TesteTecnico.Domain.Enums;

namespace TesteTecnico.Domain.Entities
{
    public class Order : BaseEntity
    {
        public virtual Product Product { get; set; }
        
        public virtual Wallet Wallet { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}