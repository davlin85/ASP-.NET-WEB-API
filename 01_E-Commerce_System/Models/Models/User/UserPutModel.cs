namespace _01_E_Commerce_System.Models.Models
{
    public class UserPutModel
    {
        public UserPutModel()
        {

        }

        public UserPutModel(int id, string firstName, string lastName, string email)
        {
            Id=id;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
        }

        public UserPutModel(int id, string firstName, string lastName, string email, string adressLine, string postalCode, string city, string country)
        {
            Id=id;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            AdressLine=adressLine;
            PostalCode=postalCode;
            City=city;
            Country=country;
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AdressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
