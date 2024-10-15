
namespace Main_App.Models;


public class Fruit 
{


    public string? Name { get; set; } = null!;
    public string Price { get; set; } = null!; //öppna upp denna och lägg till någon typ av justering

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string CategoryId { get; set; } = null!;

    public string DisplayName => $"{Name} {Price} SEK ";


     public Fruit(string _name, string _price, string _categoryId) //Detta är konstruktorn så att jag kan fylla i direkt i parentesen när jag skapar en produkt //VARFÖR BEHÖVER JAG DETTA i detta scenario?
    {
        Name = _name;
        Price = _price;
        CategoryId = _categoryId;

    }
    
}
