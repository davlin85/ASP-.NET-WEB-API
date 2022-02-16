using System.Text.RegularExpressions;

namespace _01_E_Commerce_System.Models.Input
{
    public class OrderInput
    {
        private string _status;
        private string _userFirstName;
        private string _adressLine;
        private string _postalCode;
        private string _city;


        public string Status
        {
            get { return _status; }
            set { _status = value.Trim(); }
        }

        public string UserFirstName
        {
            get { return _userFirstName; }
            set { _userFirstName = value.Trim(); }
        }

        public DateTime Created { get; set; }


        public string AdressLine
        {
            get { return _adressLine; }
            set { _adressLine = value.Trim(); }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value.Replace(" ", ""); }
        }

        public string City
        {
            get { return _city; }
            set { _city = value.Trim(); }
        }
    }
}
