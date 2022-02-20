namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPutModel
    {
        public OrderPutModel()
        {

        }


        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDateUpdated { get; set; } = DateTime.UtcNow;
        public string FirstName { get; set; }
        public string AdressLine { get; set; }

    }
}
