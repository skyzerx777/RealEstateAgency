using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string ContactInformation { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public decimal CommissionPercentage { get; set; }
    }
}
