using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,0)")]
        public decimal ArticleNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,0)")]
        public decimal Quantity { get; set; }


        [Required]
        public int CategoriesId { get; set; }
        public CategoryEntity Categories { get; set; }


        public ICollection<OrderEntity> Orders { get; set; }
    }
}
