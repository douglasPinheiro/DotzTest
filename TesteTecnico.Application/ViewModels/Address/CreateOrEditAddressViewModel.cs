using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Application.ViewModels.Address
{
    public class CreateOrEditAddressViewModel
    {
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string Street { get; set; }

        public int Number { get; set; }
    }
}
