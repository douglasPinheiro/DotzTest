using System;

namespace TesteTecnico.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public DateTime CreatedAt { get; set; }
    }
}
