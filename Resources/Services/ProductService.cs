using Main_App.Models;
using Newtonsoft.Json;
using Resources.Interfaces;
using Resources.Services;
using System.Diagnostics;

namespace Main_App.Services;

public class ProductService : IProductService<Product, Product>
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Johannasproducts.json"); // Bygger upp säkväg automatiskt beroende på vilken dator man är på
    private readonly IFileService _fileService; 
    /*
    ProductService vill använda fileService och instansierar en lokal variabel som heter
    _fileService som kommer användas mer nedan i konstruktorn 
    */
    private List<Product> _products = new List<Product>(); //HÄR SKAPAS SJÄLVA LISTAN 


    public ProductService() // <-- Konstruktorn
    {
        _fileService = new FileService(_filePath);

        _products = [];

        CreateFile(); //Skapar filen - Det sker alltså så fort product service instanseras?
    }


    public ResponseResult<Product> CreateFile()
    {
        _fileService.SaveToFile("List of Products:"); //Måste jag skicka med ett värde här
        return new ResponseResult<Product> { Success = true };
    }


    

    public ResponseResult<Product> AddProductToList(Product product) 
    {
        try 
        {
           
            if (!_products.Any(x => x.Name == product.Name)) 
            {
                
                _products.Add(product);
                Console.WriteLine($"Your product have been added to the List: \nProductname: {product.Name}, Price: {product.Price} SEK , Category is set to {product.CategoryId}");
                Console.WriteLine("Press Any key to Continue");
                return new ResponseResult<Product> { Success = true }; 

            }
        }
        catch (Exception ex)
                {
                Debug.WriteLine($"ERROR: {ex.Message}");
                }


        Console.WriteLine("\n WARNING! Productname already exists, product has not been saved to list or file.");
        return new ResponseResult<Product> { Success = false, Message = "Name of product already exists, choose new name."};
    }


    public ResponseResult<IEnumerable<Product>> AddProductsFromFile() //NÄR Ska jag använda denna metod. lägger den till prod från filen till listan?
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
    public ResponseResult<IEnumerable<Product>> GetAllProducts()
    {
        try
        {

            //AddProductsFromFile();
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Name}, {product.Price} SEK");
                Console.WriteLine($"Uniqe ID {product.Id}");
                Console.WriteLine($"Category {product.CategoryId} \n");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
        return new ResponseResult<IEnumerable<Product>> { Success = true }; 
        }


    public ResponseResult<Product> UpdateProduct(string id)
    {
        //AddProductsFromFile(); //hämtar först alla produkter VARFÖR de är väl bara sparade lokalt när programmet körs

        try
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
           
            //NEDAN SKA EGENTLIGEN LIGGA UNDER ANDRA METODEN "UPDATE". BEHÖVS då denna metod?
            Console.Clear();
            Console.WriteLine($"Update name or Price for \n");
            Console.WriteLine($"{product.Name}, {product.Price} SEK\n");
     
            Console.WriteLine($"\nPress Any key");

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"\n New Name:");
            product.Name = Console.ReadLine() ?? "";

            Console.WriteLine($"\n New Price:");
            product.Price = Console.ReadLine() ?? "";

            Console.WriteLine("Press Any key To view update.");
            Console.Clear();

            Console.WriteLine($"Updated Name: {product.Name} \n");
            Console.WriteLine($"Updated price: {product.Price} \n");

            Console.WriteLine("Press Any key to return to Main Menu");
            Console.ReadKey();

            return new ResponseResult<Product> { Success = true, Message = "We have found your product." };
        }
        catch
        {
            return null!;
        }
    }

  
  

    public ResponseResult<Product> DeleteProduct(string id)
    {
        try
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            Console.Clear();
            Console.WriteLine($"Press to delete product \n");
            Console.WriteLine($"{product.Name}, {product.Price} SEK\n");

            Console.ReadKey();
            Console.Clear();

            _products.Remove(product);

            return new ResponseResult<Product> { Success = true, Message = "We have deleted your product." };

        }
        catch
        {
            return null!;
        }
    }


}

