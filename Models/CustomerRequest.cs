using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class CustomerRequest
    {
        [Key]
        public Guid RequestID { get; set; }

        [Required]
        public Guid PropertyID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null;
    }
}
