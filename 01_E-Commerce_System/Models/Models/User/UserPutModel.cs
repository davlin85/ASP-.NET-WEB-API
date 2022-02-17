namespace _01_E_Commerce_System.Models.Models
{
    public class UserPutModel
    {
        public UserPutModel()
        {

        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AdressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
