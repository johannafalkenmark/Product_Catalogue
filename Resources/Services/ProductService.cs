//Skapa funktion som lägger till produkt i listan
//Skapa funktion som visar alla prdukter i listan ID,man och pris (FOREACH loop)
//Implementera en funktion för att ta bort en produkt från listan baserat på dess ID.
//Implementera en funktion för att uppdatera en produkts namn och pris baserat på dess ID
//Lägg till en kontroll i funktionen som lägger till en produkt för att säkerställa att produkter med samma namn inte kan läggas till två gånger.

using Main_App.Interfaces;
using Main_App.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Main_App.Services;

public class ProductService : IProductService<Product, Product>
{
    private readonly IFileService _fileService; //Jag instanserar filen
    public List<Product> _products = []; //HÄR SKAPAS SJÄLVA LISTAN 





    public ProductService(string filePath)
    {
        _fileService = new FileService(filePath);
        _products = [];
        AddProductsFromFile(); //Börjar med att hämta befinliga listan/filen
    }

    public ResponseResult<IEnumerable<Product>> AddProductsFromFile()
    {
        try
        {
            var result = _fileService.GetFromFile();
            Console.WriteLine(result);

            if (result.Success)
            {
                _products = JsonConvert.DeserializeObject<List<Product>>(result.Result!)!;
                Console.WriteLine("Success!!!");
                return new ResponseResult<IEnumerable<Product>> { Success = true, Result = _products };
            }
            else
                Console.WriteLine("hamnar i else");
                return new ResponseResult<IEnumerable<Product>> { Success = false, Message = result.Message };
        }
        catch (Exception ex)
        {
            Console.WriteLine("hamnar i catch");
            Console.WriteLine(ex.Message);
            return new ResponseResult<IEnumerable<Product>> { Success = false, Message = ex.Message };
        }
    }



    public ResponseResult<Product> AddProductToList(Product product) //Här är metoden för att LÄGGA TILL PRODUKT i listan. SKALL Alla metoder läggas till i klassen Product service? ResponseResult betyder att jag vill få tillabaka svar om det fungerat? en bool, innehåll och meddelande?
    {
        try //lägger till try catch för att fånga upp error ifall det kraschar

        {
            if (!_products.Any(x => x.Name == product.Name)) //Säger om namnet på produkt inte redan finns - lägg till produkt

            {
                _products.Add(product);
                Console.WriteLine($"You have added Productname: {product.Name}, Price: {product.Price} , Category is set to {product.CategoryId}"); //HUR får jag in inlagda namnen/variablerna på produkten
                return new ResponseResult<Product> { Success = true }; //Här lägga till response result istället? JA :)

            }



        }
        catch (Exception ex)
                {
                Debug.WriteLine($"ERROR: {ex.Message}");
                }

        return new ResponseResult<Product> { Success = false, Message = "Name of product already exists, choose new name."};


        
        
        
        
    }







    public ResponseResult<Product> RemoveProductFromListBasedOnID(string ID)
    {
        throw new NotImplementedException();
    }




    public ResponseResult<IEnumerable<Product>> ShowAllProductsInList()
    {

        foreach (Product product in _products)
        {
            Console.WriteLine(product.Name);
        }
        return new ResponseResult<IEnumerable<Product>> { Success = true }; 
        }


    public ResponseResult<Product> UpdateProductNameOrPriceBasedOnID(string ID, Product product)
    {
        throw new NotImplementedException();
    }
}

//EXEMPEL NEDAN PÅ USER LIST MENU:
//
/*
private static void ListAllUSersMenu()
{
Console.Clear();
Console.WriteLine("-- USER LIST --");

var users = _userService.GetAllUsers();
if (users != null)

foreach (var user in users)
{
    Console.WriteLine($"{user.FirstName} {user.LastName} {user.Email}");
}
else
{
Console.WriteLine("No Users was found.");
}
Console.ReadKey();
{

}
}

*/