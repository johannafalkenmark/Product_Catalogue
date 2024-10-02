using Main_App.Models;
using Main_App.Services;
using Resources.Interfaces;

namespace Main_App.Menus;

public class Product_Menu
{
    //HANS säger att jag kan ha den här nedan det är lugnt för jag kallar bara på klassen Menu service en gång (så filen ska inte skapas flera gånger).
    //kan ta bort instanseringen från program. Ta bort static från vissa ställen för de kan ej ärva. behöver nu instansera menuservice (hur? i program?) 
    public IProductService<Product, Product> _productService = new ProductService();
    private readonly IFileService _fileService;

    public void MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option)) //Varför fungerar ej denna
        {
            switch (option)
            { //Ändra så att de är ints"1" etc
                case 1:
                    AddNewProductMenu();

                    break;

                case 2:
                    ViewAllProductsMenu();
                    break;

                case 3:
                    UpdateMenu();
                    break;

                case 4:
                    RemoveMenu();
                    break;

                case 5:
                    SaveToFileMenu();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;


                default:
                    Console.WriteLine("\n Invalid option selected, try again");
                    Console.ReadKey();
                    break;
            }

        }

    }



 
    public void AddNewProductMenu()
    {
        Console.Clear();
        Console.WriteLine("---CREATING/ADDING PRODUCT---");

        Console.Write("Enter name of product: ");
        string productName = Console.ReadLine() ?? "";

        Console.Write("Price of product: ");
        string productPrice = Console.ReadLine() ?? "";

        Console.Write("Category of product (Enter 1-3): ");
        string productCategoryId = Console.ReadLine() ?? "";

        Console.Clear();
        Console.WriteLine($"You have entered: ");


        Console.WriteLine($"Name: {productName}");
        Console.WriteLine($"Price: {productPrice}  ");
        Console.WriteLine($"Category: {productCategoryId}");

        var product = new Product(productName, productPrice, productCategoryId);

        Console.WriteLine($"Product ID: {product.Id} \n");


        _productService.AddProductToList(product); 

    }
    public void ViewAllProductsMenu()
    {
        var productList = _productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("View All Products \n");

        _productService.GetAllProducts();

        Console.WriteLine("Press Any key to continue.");
        Console.ReadKey();

    }



    public void UpdateMenu()
    {
        Console.Clear();
        Console.WriteLine("View product to update  \n ");

        Console.WriteLine("Enter product ID: ");
        var Id = Console.ReadLine() ?? "";

        var product = _productService.UpdateProduct(Id); //vill ha denna inom if satsen
        if (product != null)
        {
            Console.Clear();
            Console.WriteLine($"We have found your product, press to view."); //Hur kan jag komma åt produktens namn tex här?
            Console.ReadKey();
            //DENNA KÖR JUST NU EFTER METODEN. lös detta. egentligen vill vi ha cw hit från metoden.




        }
        else
        {
            Console.WriteLine("No product was found \n");
        }

    }

    private void RemoveMenu()
    {
        Console.Clear();
        Console.WriteLine("Enter product ID to delete product  \n ");
        var Id = Console.ReadLine() ?? "";

        var product = _productService.DeleteProduct(Id); //Vill att if satsen körs

        if (product != null)
        {
            Console.Clear();
            Console.WriteLine($"We have found your product, press to view."); //Hur kan jag komma åt produktens namn tex här?
            Console.ReadKey();
            //DENNA KÖR JUST NU IF SATSEN EFTER METODEN. lös detta.

        }
        else
        {
            Console.WriteLine("No product was found \n");
        }
       
    }

    public void SaveToFileMenu()
    {
        _fileService.SaveToFile("jj"); // HUR Kallar jag på fil menyn - måste jag skicka med string?
        Console.WriteLine("Your products have been saved to file. \n Press Any key.");
        Console.ReadKey();
    }

    static void ExitApplicationMenu()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? Enter y/n.");
            var answer = Console.ReadLine(); //lägga till här answer.ToLower?
            if (answer == "n")
                Environment.Exit(0);
        }
    }
