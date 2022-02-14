using _01_E_Commerce_System.Models.Models.Category;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    [Index(nameof(ProductName), IsUnique = true)]

    public class ProductEntity
    {
        public ProductEntity(decimal articleNumber, string productName, string description, decimal price, decimal quantity)
        {
            ArticleNumber=articleNumber;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
        }

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
