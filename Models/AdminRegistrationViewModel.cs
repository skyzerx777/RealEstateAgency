using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace RealEstateAgency.Models
{
    public class AdminRegistrationViewModel
    {
        [Key]
        public Guid AdminID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Введіть логін")]
        [StringLength(10)]
        public string Username { get; set; }

        [Display(Name = "Password")]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; } = "admin";
    }
}
