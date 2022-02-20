namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPostModel 
    {
        public OrderPostModel()
        {

        }

        public OrderPostModel(int id, string orderNumber, string status, string productName, decimal quantity, DateTime orderDate, string firstName, OrderAdressModel adress)
        {
            Id=id;
            OrderNumber=orderNumber;
            Status=status;
            ProductName=productName;
            Quantity=quantity;
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
        public OrderAdressModel Adress { get; set; }

    }

}
