using _01_E_Commerce_System.Models.Models.Category;

namespace _01_E_Commerce_System.Models.Models.Product
{
    public class ProductGetPostModel
    {
        public ProductGetPostModel()
        {
                
        }

        public ProductGetPostModel(int id, string productName, string description, decimal price, decimal quantity, CategoryModel categories)
        {
            Id=id;
            ProductName=productName;
            Description=description;
            Price=price;
            Quantity=quantity;
            Categories=categories;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public CategoryModel Categories { get; set; }
    }
}
