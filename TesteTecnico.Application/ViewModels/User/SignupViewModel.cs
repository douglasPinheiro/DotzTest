using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Application.ViewModels.User
{
    public class SignupViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$", ErrorMessage = "O campo CPF deve estar no formato: 000.000.000-00")]
        public string CPF { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public string Mobile { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
