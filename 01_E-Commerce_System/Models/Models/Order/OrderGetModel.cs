using _01_E_Commerce_System.Models.Models.Adress;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderGetModel
    {
        public OrderGetModel()
        {

        }

        public OrderGetModel(int id, string orderNumber, string status, string productName, decimal quantity, DateTime orderDate, string firstName, AdressModel adress)
        {
            Id=id;
            OrderNumber=orderNumber;
            Status=status;
            ProductName=productName;
            Quantity=quantity;
            OrderDate=orderDate;
            FirstName=firstName;
            Adress=adress;
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string FirstName { get; set; }
        public AdressModel Adress { get; set; }
    }

}
 