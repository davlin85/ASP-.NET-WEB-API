using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Entities
{
    [Index(nameof(ProductName), IsUnique = true)]

    public class ProductEntity
    {

        public ProductEntity(string productName, string description, decimal price, decimal quantity)
        {
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
        }

        [Key]
        public int Id { get; set; }

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
        [Column(TypeName = "decimal(8,2)")]
        public decimal Quantity { get; set; }

        [Required]
        public int CategoriesId { get; set; }
        public CategoryEntity Categories { get; set; }

    }
}
