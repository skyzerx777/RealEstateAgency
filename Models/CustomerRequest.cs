using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class CustomerRequest
    {
        [Key]
        public int RequestID { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyType { get; set; } = string.Empty;

        [Required]
        public bool IsForRent { get; set; }

        public int? NumBedrooms { get; set; }

        public int? NumBathrooms { get; set; }

        public int? SquareFootage { get; set; }

        public decimal? Budget { get; set; }
    }
}
