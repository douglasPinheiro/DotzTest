using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnico.Domain.Entities
{
    public class User :  IdentityUser
    {
        [Required]
        public string CPF { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        public string Mobile { get; set; }
        
        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }

        //public virtual Wallet Wallet { get; set; }
    }
}
