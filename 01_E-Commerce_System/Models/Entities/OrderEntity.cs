using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(string orderNumber, string status, string productName, decimal quantity, DateTime orderDate, string firstName)
        {
            OrderNumber=orderNumber;
            Status=status;
            ProductName=productName;
            Quantity=quantity;
            OrderDate=orderDate;
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

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        public int AdressesId { get; set; }
        public AdressEntity Adresses { get; set; }

    }
}
