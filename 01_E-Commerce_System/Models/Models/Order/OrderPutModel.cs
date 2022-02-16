using _01_E_Commerce_System.Models.Models.Adress;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPutModel
    {
        public OrderPutModel()
        {

        }


        public OrderPutModel(int id, string usersFirstName, DateTime orderDate, string status, AdressModel adress)
        {
            Id=id;
            UsersFirstName=usersFirstName;
            OrderDate=orderDate;
            Status=status;
            Adress=adress;

        }

        public int Id { get; set; }
        public string UsersFirstName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public AdressModel Adress { get; set; }

    }
}
