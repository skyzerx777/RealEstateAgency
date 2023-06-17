using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Models
{
    public enum Status
    {
        [Display(Name = "Продаж")]
        Sale,
        [Display(Name = "Оренда")]
        Rent,
        [Display(Name = "Продано")]
        Sold
    }

    public enum PropertyType
    {
        [Display(Name = "Будинок")]
        House,
        [Display(Name = "Квартира")]
        Apartment,
        [Display(Name = "Земельна ділянка")]
        Land
    }
    public class Property
    {
        [Key]
        public Guid PropertyID { get; set; }

        [Required]
        [EnumDataType(typeof(PropertyType))]
        public PropertyType PropertyType { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Перевірте правильність введених даних")]
        public string Address { get; set; }

        public int? Price { get; set; }

        public bool IsForRent { get; set; }

        public int? RentPrice { get; set; }

        public int? NumBedrooms { get; set; }

        public int? NumBathrooms { get; set; }

        public int SquareFootage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Pictures { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
    }
}
