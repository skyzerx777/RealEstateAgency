using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public class Property
    {
        [Key]
        public Guid PropertyID { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyType { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsForRent { get; set; }

        public decimal? RentPrice { get; set; }

        public int? NumBedrooms { get; set; }

        public int? NumBathrooms { get; set; }

        public int SquareFootage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Pictures { get; set; }

        public string Status { get; set; }
    }
}
