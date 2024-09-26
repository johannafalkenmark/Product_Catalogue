////Menu service - inte lika viktigt testa i denna.¨Console write/read line endast i denna

using Main_App.Models;
using Main_App.Services;
using Resources.Interfaces;
using System.IO;

namespace Resources.Services;

public class MenuService
{
    //HANS säger att jag kan ha den här nedan det är lugnt för jag kallar bara på klassen Menu service en gång (så filen ska inte skapas flera gånger).
    //kan ta bort instanseringen från program. Ta bort static från vissa ställen för de kan ej ärva. behöver nu instansera menuservice (hur? i program?) 
    public IProductService<Product, Product> _productService = new ProductService();


    public void MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option)
            {
                case 1:
                    AddNewProductMenu();

                    break;

                case 2:
                   ViewAllProductsMenu();
                    break;

                case 3:
                    ViewSingleMenu();
                    break;

                case 4:
                    //Remove product
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

        Console.WriteLine($"Thank you, the following product is saved: ");


        Console.WriteLine($"Name: {productName}");
        Console.WriteLine($"Price: {productPrice}  ");
        Console.WriteLine($"Category: {productCategoryId}");

        var product = new Product(productName, productPrice, productCategoryId);

        Console.WriteLine($"Automatic generated Product ID: {product.Id}");


        _productService.AddProductToList(product); //Här läggs den till i listan

    }
    public void ViewAllProductsMenu()
{
    var productList = _productService.GetAllProducts(); //Skapa denna metod

    Console.Clear();
    Console.WriteLine("View All Products \n");

        _productService.GetAllProducts();

    Console.WriteLine("Press Any key to continue.");
    Console.ReadKey();

}



    public void ViewSingleMenu()
    {
        Console.Clear();
        Console.WriteLine("View product to update  \n ");

        Console.WriteLine("Enter product ID: ");
        var Id = Console.ReadLine() ?? "";

        var product = _productService.GetSingleProduct(Id);
        if (product != null)
        {
            Console.Clear();
            Console.WriteLine($"We have found your product, press to view."); //Hur kan jag komma åt produktens namn tex här?
            Console.ReadKey();
            //DENNA KÖR JUST NU IF SATSEN EFTER METODEN. lös detta. egentligen vill vi ha cw hit från metoden.
          
        }
        else
        {
            Console.WriteLine("No product was found \n");
        }
        

        

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






