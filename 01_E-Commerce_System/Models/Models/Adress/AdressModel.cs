using _01_E_Commerce_System.Models.Models.Product;

namespace _01_E_Commerce_System.Models.Models.Adress
{
    public class AdressModel
    {
        public AdressModel()
        {

        }

        public AdressModel(string adressLine, string postalCode, string city, string country)
        {
            AdressLine = adressLine;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }


        public string AdressLine { get; set;}
        public string PostalCode { get; set;}
        public string City { get; set;}
        public string Country { get; set;}

    }
}
