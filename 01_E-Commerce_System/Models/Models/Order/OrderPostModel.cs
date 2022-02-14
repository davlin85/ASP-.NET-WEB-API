using _01_E_Commerce_System.Models.Models.Adress;
using _01_E_Commerce_System.Models.Models.Category;
using _01_E_Commerce_System.Models.Models.Product;
using _01_E_Commerce_System.Models.Models.User;

namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderPostModel
    {
        public OrderPostModel()
        {

        }

        public OrderPostModel(int id, DateTime created, string status, UserGetModel userGetModel)
        {
            Id=id;
            Created=created;
            Status=status;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Status { get; set; }
        public UserPostModel User { get; set; }
        public ProductGetPostModel Product { get; set; }

    }
}
