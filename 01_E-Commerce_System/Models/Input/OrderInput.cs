namespace _01_E_Commerce_System.Models.Forms
{
    public class OrderInput
    {
        private int _userId;
        private DateTime _created;
        private string _status;
        private int _productId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value.Trim(); }
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

    }
}
