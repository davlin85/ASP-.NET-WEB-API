using _01_E_Commerce_System.Models.Models.Adress;
using _01_E_Commerce_System.Models.Models.Category;
using _01_E_Commerce_System.Models.Models.Product;
using _01_E_Commerce_System.Models.Models.User;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderGetModel
    {
        public OrderGetModel()
        {

        }


        public OrderGetModel(string userFirstName, DateTime orderDate, string status)
        {
            UserFirstName=userFirstName;
            OrderDate=orderDate;
            Status=status;
        }

        public OrderGetModel(int id, string userFirstName, DateTime orderDate, AdressModel adressModel)
        {
            Id=id;
            UserFirstName=userFirstName;
            OrderDate=orderDate;
        }

        public OrderGetModel(int id, string userFirstName, DateTime orderDate, string status, AdressModel adress)
        {
            Id=id;
            UserFirstName=userFirstName;
            Status=status;
            OrderDate=orderDate;
            Adress=adress;
        }

        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public AdressModel Adress { get; set; }

    }

}
