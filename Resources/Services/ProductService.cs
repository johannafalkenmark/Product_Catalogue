using Main_App.Models;
using Newtonsoft.Json;
using Resources.Interfaces;
using Resources.Services;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Main_App.Services;

public class ProductService : IProductService<Fruit, Fruit>
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "FRUITBASKET.json"); // Bygger upp säkväg automatiskt beroende på vilken dator man är på
    private readonly IFileService _fileService; 
    /*
    ProductService vill använda fileService och instansierar en lokal variabel som heter
    _fileService som kommer användas mer nedan i konstruktorn 
    */
    private List<Fruit> _products = new List<Fruit>(); //HÄR SKAPAS SJÄLVA LISTAN 


    public ProductService() // <-- Konstruktorn
    {
        _fileService = new FileService(_filePath);

        _products = [];

        CreateFile(); 
    }


    public ResponseResult<Fruit> CreateFile()
    {
        //gör json konvertering inför att skriva till filen
        _fileService.SaveToFile("FRUITS"); //Här ska konvertart json format skickas in. 
        return new ResponseResult<Fruit> { Success = true };
    }

    public ResponseResult<Fruit> GetProductFromName(string Name)
    {
        try
        {
            var result = _products.FirstOrDefault(x => x.Name == Name);
            if (result == null)
            {
                return new ResponseResult<Fruit> { Message = "Can't find productname", Success = false };
            }
            return new ResponseResult<Fruit> {Result = result, Success = true };
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
            return new ResponseResult<Fruit> { Success = false, Message = ex.Message };
        }

    }


    public ResponseResult<Fruit> AddProductToList(Fruit product) 
    {
        try 
        {
           
            if (!_products.Any(x => x.Name == product.Name)) 
            {
                
                _products.Add(product);
                Console.WriteLine($"Your product have been added to the List: \nProductname: {product.Name}, Price: {product.Price} SEK , Category is set to {product.CategoryId}");
                Console.WriteLine("Press Any key to Continue");
                return new ResponseResult<Fruit> { Success = true }; 

            }
        }
        catch (Exception ex)
                {
                Debug.WriteLine($"ERROR: {ex.Message}");
                }


        Console.WriteLine("\n WARNING! Productname already exists, product has not been saved to list or file.");
        return new ResponseResult<Fruit> { Success = false, Message = "Name of product already exists, choose new name."};
    }


    public ResponseResult<IEnumerable<Fruit>> AddProductsFromFile() //NÄR Ska jag använda denna metod. lägger den till prod från filen till listan?
    {
        try
        {
            var result = _fileService.GetFromFile();
            Console.WriteLine(result);

            if (result.Success)
            {
                _products = JsonConvert.DeserializeObject<List<Fruit>>(result.Result!)!;
                Console.WriteLine("Success!!!");
                return new ResponseResult<IEnumerable<Fruit>> { Success = true, Result = _products };
            }
            else
                Console.WriteLine("hamnar i else");
            return new ResponseResult<IEnumerable<Fruit>> { Success = false, Message = result.Message };
        }
        catch (Exception ex)
        {
            Console.WriteLine("hamnar i catch");
            Console.WriteLine(ex.Message);
            return new ResponseResult<IEnumerable<Fruit>> { Success = false, Message = ex.Message };
        }

    }
    public ResponseResult<IEnumerable<Fruit>> GetAllProducts()
    {

        try
        {

           // AddProductsFromFile();
            foreach (Fruit product in _products)
            {
 
                Console.WriteLine($"{product.Name}, {product.Price} SEK");
                Console.WriteLine($"Uniqe ID {product.Id}");
                Console.WriteLine($"Category {product.CategoryId} \n");
                //Lägga till att visa category name här? 
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
        return new ResponseResult<IEnumerable<Fruit>> { Success = true }; 
        }


    public ResponseResult<Fruit> GetProduct(string id)
    {
        //AddProductsFromFile(); 

        try
        {
            
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return new ResponseResult<Fruit> { Result = product, Success = true, Message = "We have found your product." };
            }
            else
            {       
                return new ResponseResult<Fruit> { Success = false, Message = "We have not found product" };
          
            }
        }
        catch
        {
            return null!;
        }
    }

  
  

    public ResponseResult<Fruit> DeleteProduct(string id)
    {
        try
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            _products.Remove(product);

            return new ResponseResult<Fruit> { Success = true, Message = "We have found and deleted product." };

        }
        catch
        {
            return new ResponseResult<Fruit> { Success = false, Message = "We have not deleted product" };
        }
        }


}

