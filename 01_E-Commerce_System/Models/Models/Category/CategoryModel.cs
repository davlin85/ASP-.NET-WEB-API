namespace _01_E_Commerce_System.Models.Models.Category
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }

        public CategoryModel(string category)
        {
            Category=category;
        }

        public string Category { get; set; }

    }
}
