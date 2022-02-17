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
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string FirstName { get; set; }
        public string AdressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }

    }
}
