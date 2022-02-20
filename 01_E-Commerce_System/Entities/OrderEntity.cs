using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Entities
{
    public class OrderEntity
    {
        public OrderEntity(string orderNumber, string status, string productName, decimal quantity, string firstName)
        {
            OrderNumber=orderNumber;
            Status=status;
            ProductName=productName;
            Quantity=quantity;
            FirstName=firstName;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string OrderNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime2")]
        public DateTime OrderDateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        public int AdressesId { get; set; }
        public AdressEntity Adresses { get; set; }

    }
}
