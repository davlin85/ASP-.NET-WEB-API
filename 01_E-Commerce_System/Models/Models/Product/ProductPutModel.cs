namespace _01_E_Commerce_System.Models.Models.Product
{
    public class ProductPutModel
    {
        public ProductPutModel()
        {
                
        }

        public ProductPutModel(int id, string productName, string description, decimal price, decimal quantity)
        {
            Id=id;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
        }

        public ProductPutModel(int id, string productName, string description, decimal price, decimal quantity, string category)
        {
            Id=id;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
            Category=category;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Category { get; set; }
    }
}
