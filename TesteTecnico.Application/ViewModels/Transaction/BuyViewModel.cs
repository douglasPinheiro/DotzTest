using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Application.ViewModels.Transaction
{
    public class BuyViewModel
    {
        [Required]
        public int ProductId { get; set; }
    }
}
