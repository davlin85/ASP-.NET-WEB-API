using _01_E_Commerce_System.Models.Models.Adress;

namespace _01_E_Commerce_System.Models.Models.User
{
    public class UserGetModel
    {
        public UserGetModel()
        {

        }

        public UserGetModel(int id, string firstName, string lastName, string email, AdressModel adress)
        {
            Id=id;
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            Adress=adress;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AdressModel Adress { get; set; }
    }
}
