using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class AdressEntity
    {
        
        public AdressEntity()
        {
            Users = new HashSet<UserEntity>();
            Orders = new HashSet<OrderEntity>();
        }

        public AdressEntity(string adressLine, string postalCode, string city)
        {
            AdressLine=adressLine;
            PostalCode=postalCode;
            City=city;
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

        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }

    }
}
