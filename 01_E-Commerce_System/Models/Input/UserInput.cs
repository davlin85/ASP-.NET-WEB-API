using System.Text.RegularExpressions;

namespace _01_E_Commerce_System.Models.Input
{
    public class UserInput
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _adressLine;
        private string _postalCode;
        private string _city;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value.Trim(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value.Trim(); }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$").IsMatch(value.Trim())) ;
                _email = value.Trim();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (new Regex(@"^(?=.*?[A-Ö])(?=.*?[a-ö])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").IsMatch(value.Trim())) ;
                _password = value.Trim();
            }
        }
        
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
