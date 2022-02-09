using _01_E_Commerce_System.Models.Output;

namespace _01_E_Commerce_System.Models
{
    public class UserPostModel
    {
        public UserPostModel()
        {

        }

        public UserPostModel(int id, string firstName, string lastName, string email, string password, AdressModel adress)
        {
            Id=id;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Password = password;
            Adress = adress;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AdressModel Adress { get; set; }
    }
}
