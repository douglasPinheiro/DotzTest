using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Application.ViewModels.Transaction
{
    public class ExchangeViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal DotzCost { get; set; }
    }
}
