using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            Products = new HashSet<ProductEntity>();
        }

        public CategoryEntity(string category)
        {
            Category=category;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Category { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
