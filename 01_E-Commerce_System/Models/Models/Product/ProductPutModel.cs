namespace _01_E_Commerce_System.Models.Models.Product
{
    public class ProductPutModel
    {
        public ProductPutModel()
        {
                
        }


        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Category { get; set; }
    }
}
