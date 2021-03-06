﻿namespace TesteTecnico.Domain.Entities
{
    public class Address : BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }
    }
}
