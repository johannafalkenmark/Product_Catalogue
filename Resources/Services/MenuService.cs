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
    public IProductService<Product, Product> _productService = new ProductService(@"C:\Projects School\Product_Catalogue\Product_Catalogue\Products.json");


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
        Console.WriteLine("---CREATING/ADDING NEW PRODUCT---");

        Console.Write("Enter name of new product: ");
        string productName = Console.ReadLine() ?? "";

        Console.Write("Price of new product: ");
        string productPrice = Console.ReadLine() ?? "";

        Console.Write("Category of product (Enter 1-3): ");
        string productCategoryId = Console.ReadLine() ?? "";

        Console.WriteLine($"Thank you, the following product is saved: ");


        Console.WriteLine($"Name of product: {productName}");
        Console.WriteLine($"Price of product: {productPrice}  ");
        Console.WriteLine($"Category of product: {productCategoryId}");
        Console.WriteLine($"Price of product: {productCategoryId}  ");


        var product = new Product(productName, productPrice, productCategoryId);

        Console.WriteLine($"Automatic generated Product ID: {product.Id}");


        _productService.AddProductToList(product); //Här läggs den till i listan

    }

    public void ViewAllProductsMenu()
    {
        var productList = _productService.GetAllProducts(); //Skapa denna metod

        Console.Clear();
        Console.WriteLine("View All Products \n");

        if (productList.Any()) //kontrollerar om det finns något i listan eller inte
        {
            foreach (Product product in _productList)
            {
                Console.WriteLine($"{product.Name} <{product.Price}> SEK");
                Console.WriteLine($"Uniqe ID {product.Id}");
                Console.WriteLine($"Category {product.CategoryId} \n");
            }
        }
        else
        {
            Console.WriteLine("No products in list. \n");
        }

        Console.WriteLine("Press Any key to continue.");
        Console.ReadKey();

    }



    public void ViewSingleMenu()
    {
        Console.Clear();
        Console.WriteLine("View product to update  \n ");

        Console.WriteLine("Enter product ID: ");
        var Id = Console.ReadLine() ?? "";

        var product = _productService.GetProduct(Id);
        if (product != null)
        {
            Console.Clear();
            Console.WriteLine($"Update name or Price for {product.Name} \n");

            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price:  {product.Price}");
            Console.WriteLine($"ID:  {product.Id}");
            Console.WriteLine($"Category: {product.CategoryId} \n");
        }
        else
        {
            Console.WriteLine("No product was found \n");
        }

        Console.WriteLine("Press Any key to continue");
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