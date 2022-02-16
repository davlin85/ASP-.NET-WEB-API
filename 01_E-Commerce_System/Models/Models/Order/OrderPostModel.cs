using _01_E_Commerce_System.Models.Models.Adress;
using _01_E_Commerce_System.Models.Models.Category;
using _01_E_Commerce_System.Models.Models.Product;
using _01_E_Commerce_System.Models.Models.User;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPostModel 
    {
        public OrderPostModel(int id, string userFirstName, DateTime orderDate, string status, AdressModel adress)
        {
            Id=id;
            UserFirstName=userFirstName;
            OrderDate=orderDate;
            Status=status;
            Adress=adress;
        }

        public OrderPostModel(string status, string userFirstName)
        {
            Status=status;
            UserFirstName=userFirstName;
        }

        public OrderPostModel(string userFirstName, DateTime orderDate, string status, AdressModel adress)
        {
            UserFirstName=userFirstName;
            OrderDate=orderDate;
            Status=status;
            Adress=adress;
        }

        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public AdressModel Adress { get; set; }

    }

}
