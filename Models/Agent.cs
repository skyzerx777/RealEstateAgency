using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class Agent
    {
        [Key]
        public Guid AgentID { get; set; }

        [Required(ErrorMessage = "Введіть ім'я")]
        [StringLength(15)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть прізвище")]
        [StringLength(20)]
        public string Surname { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(0, 100)]
        public int CommissionPercentage { get; set; }
    }
}
