using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class AdressEntity
    {
        public AdressEntity()
        {

        }

        public AdressEntity(string adressLine, string postalCode, string city, string country)
        {
            AdressLine=adressLine;
            PostalCode=postalCode;
            City=city;
            Country=country;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string AdressLine { get; set; }

        [Required]
        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
