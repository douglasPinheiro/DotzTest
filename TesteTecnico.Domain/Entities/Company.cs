namespace TesteTecnico.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        
        public string CNPJ { get; set; }

        public virtual Address Address { get; set; }
    }
}