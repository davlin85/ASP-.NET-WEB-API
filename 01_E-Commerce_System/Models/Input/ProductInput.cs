namespace _01_E_Commerce_System.Models.Input
{
    public class ProductInput
    {
        private decimal _articleNumber;
        private string _productName;
        private string _description;
        private string _category;
        private decimal _price;
        private decimal _quantity;

        public decimal ArticleNumber 
        { 
            get { return _articleNumber; } 
            set { _articleNumber = value; } 
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value.Trim(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value.Trim(); }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value.Trim(); }
        }
    }
}
