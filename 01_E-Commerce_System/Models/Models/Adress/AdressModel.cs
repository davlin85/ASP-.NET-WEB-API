namespace _01_E_Commerce_System.Models.Models.Adress
{
    public class AdressModel
    {
        public AdressModel()
        {

        }

        public AdressModel(string adressLine, string postalCode, string city)
        {
            AdressLine = adressLine;
            PostalCode = postalCode;
            City = city;
        }


        public string AdressLine { get; set;}
        public string PostalCode { get; set;}
        public string City { get; set;}

    }
}
