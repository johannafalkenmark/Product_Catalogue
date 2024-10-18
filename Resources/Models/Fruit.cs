namespace Main_App.Models;

public class Fruit 
{
    public string Name { get; set; } = null!;
    public string Price { get; set; } = null!; 

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string CategoryId { get; set; } = null!;

    public string DisplayName => $"{Name} {Price} SEK \n{Id}";


     public Fruit(string _name, string _price, string _categoryId)  
    {
        Name = _name;
        Price = _price;
        CategoryId = _categoryId;
    }
    
}
