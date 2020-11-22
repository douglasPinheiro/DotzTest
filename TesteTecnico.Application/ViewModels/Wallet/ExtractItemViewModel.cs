using System;
using TesteTecnico.Application.ViewModels.Company;
using TesteTecnico.Application.ViewModels.Product;
using TesteTecnico.Domain.Enums;

namespace TesteTecnico.Application.ViewModels.Wallet
{
    public class ExtractItemViewModel
    {
        public decimal DotzCost { get; set; }

        public TransactionType TransactionType { get; set; }

        public ProductItemViewModel Product { get; set; }

        public CompanyItemViewModel Company { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
