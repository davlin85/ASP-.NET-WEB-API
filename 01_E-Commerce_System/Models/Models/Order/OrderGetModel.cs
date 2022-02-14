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

        public OrderGetModel(int id, DateTime updated, DateTime created, string status, UserGetModel userGetModel)
        {
            Id=id;
            Updated=updated;
            Created=created;
            Status=status;
        }

        public OrderGetModel(int id, DateTime created, DateTime updated, string status, UserPostModel user, ProductGetPostModel product)
        {
            Id=id;
            Created=created;
            Updated=updated;
            Status=status;
            User=user;
            Product=product;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Status { get; set; }
        public UserPostModel User { get; set; }
        public ProductGetPostModel Product {get; set;}

    }
}
