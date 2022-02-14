namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPutModel
    {
        public OrderPutModel()
        {

        }

        public OrderPutModel(int id, DateTime updated, DateTime created, string status, string firstName, string lastName, string email, string adressLine, string postalCode, string city, string country, decimal articleNumber, string productName, string description, decimal price, decimal quantity, string categoryName)
        {
            Id=id;
            Updated=updated;
            Created=created;
            Status=status;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            AdressLine=adressLine;
            PostalCode=postalCode;
            City=city;
            Country=country;
            ArticleNumber=articleNumber;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
            CategoryName=categoryName;
        }

        public int Id { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AdressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public decimal ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
