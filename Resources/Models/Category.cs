
namespace Main_App.Models
{
    public class Category
    {

        public string Name { get; set; } = null!;
        public string Id { get; set; } = null!;

        public Category(string _name, string _id)
        {
            Name = _name;
            Id = _id;
        }
    }
}
