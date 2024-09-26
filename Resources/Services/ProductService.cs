//Skapa funktion som lägger till produkt i listan
//Skapa funktion som visar alla prdukter i listan ID,man och pris (FOREACH loop)
//Implementera en funktion för att ta bort en produkt från listan baserat på dess ID.
//Implementera en funktion för att uppdatera en produkts namn och pris baserat på dess ID
//Lägg till en kontroll i funktionen som lägger till en produkt för att säkerställa att produkter med samma namn inte kan läggas till två gånger.

using Main_App.Models;
using Newtonsoft.Json;
using Resources.Interfaces;
using Resources.Services;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Main_App.Services;

public class ProductService : IProductService<Product, Product>
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Johannasprodukter.json"); //Bygger upp säkväg automatiskt beroende på vilken dator man är på
    private readonly IFileService _fileService; //Jag instanserar filen
    private List<Product> _products = new List<Product>(); //HÄR SKAPAS SJÄLVA LISTAN 

/*
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
*/

    public ResponseResult<Product> AddProductToList(Product product) 
    {
        try 

        {

            //LÄGG till AddProductsFromfile(); 
            if (!_products.Any(x => x.Name == product.Name)) //Säger om namnet på produkt inte redan finns - lägg till produkt

            {
                _products.Add(product);
                Console.WriteLine($"Your product have been added to the List: \n Productname: {product.Name}, Price: {product.Price} , Category is set to {product.CategoryId}"); 
                return new ResponseResult<Product> { Success = true }; 

            }



        }
        catch (Exception ex)
                {
                Debug.WriteLine($"ERROR: {ex.Message}");
                }
       
    
        return new ResponseResult<Product> { Success = false, Message = "Name of product already exists, choose new name."};
 
    }



    public ResponseResult<IEnumerable<Product>> GetAllProducts()
    {

        //AddProductsFromFile();

        foreach (Product product in _products)
        {
            Console.WriteLine(product.Name);
        }
        return new ResponseResult<IEnumerable<Product>> { Success = true }; 
        }

   


    public Product GetProduct(string id)
    {
        //AddProductsFromFile(); //hämtar först alla produkter

        try
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product ?? null!; //retiurenera produkten eller returnera null
        }
        catch
        {
            return null!;
        }
    }

   

    public ResponseResult<Product> UpdateProductNameOrPriceBasedOnID(string ID, Product product) //Skapa metoden för att uppdatera här. först kalla på get product metoden?
    {
        

        throw new NotImplementedException();
    }

    public ResponseResult<Product> RemoveProductFromListBasedOnID(string ID)
    {
        throw new NotImplementedException();
    }


}

