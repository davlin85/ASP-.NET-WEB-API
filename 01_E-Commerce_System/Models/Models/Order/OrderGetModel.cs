using _01_E_Commerce_System.Models.Models.Adress;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderGetModel
    {
        public OrderGetModel()
        {

        }

        public OrderGetModel(int id, string orderNumber, string status, DateTime orderDate, string firstName, string productName, decimal quantity, AdressModel adress)
        {
            Id=id;
            OrderNumber=orderNumber;
            Status=status;
            OrderDate=orderDate;
            FirstName=firstName;
            ProductName=productName;
            Quantity=quantity;
            Adress=adress;
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string FirstName { get; set; }
        public AdressModel Adress { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }

}
