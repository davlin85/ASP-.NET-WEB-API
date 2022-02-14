namespace _01_E_Commerce_System.Models.Models.Category
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }

        public CategoryModel(string categoryName)
        {
            CategoryName=categoryName;
        }

        public string CategoryName { get; set; }

    }
}
