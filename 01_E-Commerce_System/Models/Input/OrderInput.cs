namespace _01_E_Commerce_System.Models.Input
{
    public class OrderInput
    {
        private string _orderNumber;
        private string _status;
        private string _productName;
        private decimal _quantity;
        private string _firstName;
        private string _adressLine;

        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value.Trim(); }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value.Trim(); }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value.Trim(); }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value.Trim(); }
        }

        public string AdressLine
        {
            get { return _adressLine; }
            set { _adressLine = value.Trim(); }
        }

    }
}
