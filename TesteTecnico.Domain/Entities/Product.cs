namespace TesteTecnico.Domain.Entities
{
    public class Product : BaseEntity
    {
        public bool IsActive { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal RewardInDotz { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual Company Company { get; set; }
    }
}
