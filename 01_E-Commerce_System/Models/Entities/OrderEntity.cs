using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_E_Commerce_System.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(string orderNumber, string status, DateTime orderDate, string firstName, string productName, decimal quantity)
        {
            OrderNumber=orderNumber;
            Status=status;
            OrderDate=orderDate;
            FirstName=firstName;
            ProductName=productName;
            Quantity=quantity;
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
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        public int AdressesId { get; set; }
        public AdressEntity Adresses { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,0)")]
        public decimal Quantity { get; set; }

    }
}
