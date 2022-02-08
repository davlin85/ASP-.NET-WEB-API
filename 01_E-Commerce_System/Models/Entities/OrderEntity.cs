using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }


        public int UsersId { get; set; }
        public UserEntity Users { get; set; }


        [Required]
        public int ProductsId { get; set; }
        public ProductEntity Products { get; set; }
    }
}
