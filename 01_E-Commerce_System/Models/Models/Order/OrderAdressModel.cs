namespace _01_E_Commerce_System.Models.Models.Order
{
    public class OrderAdressModel
    {
        public OrderAdressModel()
        {

        }

        public OrderAdressModel(string adressLine)
        {
            AdressLine = adressLine;
        }


        public string AdressLine { get; set; }

    }
}
