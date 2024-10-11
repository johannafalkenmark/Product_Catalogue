using Main_App.Models;
using Newtonsoft.Json;
using Resources.Interfaces;
using Resources.Services;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Main_App.Services;

public class ProductService : IProductService<Fruit, Fruit>
{

    private static string fileName = "FruitBasket.json";
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, fileName); // Bygger upp säkväg automatiskt beroende på vilken dator man är på
    private readonly IFileService _fileService; 
    /*
    ProductService vill använda fileService och instansierar en lokal variabel som heter
    _fileService som kommer användas mer nedan i konstruktorn 
    */
    private List<Fruit> _products = new List<Fruit>(); //HÄR SKAPAS SJÄLVA LISTAN 


    public ProductService() 
    {
        _fileService = new FileService(_filePath);

        _products = [];
        AddProductsFromFile();
    }


    public ResponseResult<Fruit> SaveProductsToFile()
    {
        // Läs nuvarande innehåll i fil
        var json = JsonConvert.SerializeObject(_products);
        _fileService.SaveToFile(json);
        return new ResponseResult<Fruit> { Success = true };
    }
    public ResponseResult<IEnumerable<Fruit>> AddProductsFromFile() 
    {
        try
        {
            var result = _fileService.GetFromFile();

            // Om Filen  inte finns - skapar ny
            if(result == null)
            {
                SaveProductsToFile(); //Skapas en fil upp i denna metod?
                return new ResponseResult<IEnumerable<Fruit>> { Success = false, Message = "File does not exist" };

            }

            if (result.Success)
            {
                _products = JsonConvert.DeserializeObject<List<Fruit>>(result.Result!)!;                
                return new ResponseResult<IEnumerable<Fruit>> { Success = true, Result = _products };
            }
            else
            {
                SaveProductsToFile();

            }
            return new ResponseResult<IEnumerable<Fruit>> { Success = false, Message = result.Message };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ResponseResult<IEnumerable<Fruit>> { Success = false, Message = ex.Message };
        }

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

    public ResponseResult<IEnumerable<Fruit>> GetAllProducts()
    {

        try
        {
            foreach (Fruit product in _products)
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
        return new ResponseResult<IEnumerable<Fruit>> { Success = true }; 
        }


    public ResponseResult<Fruit> GetProduct(string id)
    {
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
            if (product != null)
            {

                _products.Remove(product);

            }

            return new ResponseResult<Fruit> { Success = true, Message = "We have found and deleted product." };

        }
        catch
        {
            return new ResponseResult<Fruit> { Success = false, Message = "We have not deleted product" };
        }
        }


}

