namespace _01_E_Commerce_System.Models.Models.Product
{
    public class ProductPutModel
    {
        public ProductPutModel()
        {
                
        }

        public ProductPutModel(int id, decimal articleNumber, string productName, string description, decimal price, decimal quantity)
        {
            Id=id;
            ArticleNumber=articleNumber;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
        }

        public ProductPutModel(int id, decimal articleNumber, string productName, string description, decimal price, decimal quantity, string categoryName)
        {
            Id=id;
            ArticleNumber=articleNumber;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
            CategoryName=categoryName;
        }

        public int Id { get; set; }
        public decimal ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
