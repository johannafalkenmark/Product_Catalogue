////Menu service - inte lika viktigt testa i denna.¨Console write/read line endast i denna

using Main_App.Interfaces;
using Main_App.Models;
using Main_App.Services;
using System.IO;

namespace Main_App.Services;

public class MenuService //Lägg till interface här?
{
    //RADEN NEDAN har jag gjort för att jag har ett interface och därför behöver jag göra detta 
    //den riskerar skapa listan varje gång product service anropas vilket jag inte vill därför flyttade till program.
    //Behöve rhitta ett sätt att anropa metoden addproductstolist från productservice hit
    
    
    
    
    //HANS säger att jag kan ha den här nedan det är lugnt för jag kallar bara på klassen Menu service en gång (så filen ska inte skapas flera gånger).
    //kan ta bort instanseringen från program. Ta bort static från vissa ställen för de kan ej ärva. behöver nu instansera menuservice (hur? i program?) 
    public IProductService<Product, Product> _productService = new ProductService(@"C:\Projects School\Product_Catalogue\Product_Catalogue\Products.json");


    public void MenuOptions(string selectedOption) //ligger som private i lektionsexempel - ändra?
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option) 
            {
                case 1:
                    AddNewProductMenu();
                    
                    break;

                case 2:
                    //showlistofallproducts();
                    break;

                case 3: 
                    //updateexistingproduct
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



    //OPTION 1:
  
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
            Console.WriteLine($"Price of product: {productCategoryId}  ");
           
  
            var product = new Product(productName, productPrice, productCategoryId);

            Console.WriteLine($"Automatic generated Product ID: {product.Id}");



       
        //HUR få tillgång till product service metoden addproducttolist:

        _productService.AddProductToList(product);

          

        }
        


    



    private void ExitApplicationMenu()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to exit? Enter y/n.");
        var answer = Console.ReadLine(); //lägga till här answer.ToLower?
        if (answer == "n") 
            Environment.Exit(0);
    }


}




/* Exempel Menu service:
* internal static class MenuService //När denna är static behöver resten vara static. KAN ej ha en konstrukor i en statisk klass.
{
private static readonly UserService _userService = new UserService();
private static void ValidOption()
{
    Console.WriteLine("Enter a valid option please");
}

private static void CreateUserMenu()
{

    var user = new User();

    Console.Clear();
    Console.WriteLine("---CREATE NEW USER---");

    Console.Write("Enter First Name: ");
    user.FirstName = Console.ReadLine() ?? "";

    Console.WriteLine("Enter last Name: ");
    user.LastName = Console.ReadLine() ?? "";

    Console.WriteLine("Enter e-mail adress: ");
    user.Email = Console.ReadLine() ?? "";

    Console.WriteLine("Enter Phone Number: ");
    user.PhoneNumber = Console.ReadLine() ?? "";

    var response = _userService.CreateUser(user);
    Console.WriteLine(response.Message);
}




private static void ExitApplicationMenu()
{
    Console.Clear();
    Console.WriteLine("Are you sure you want to exit? (y/n)?");
    var answer = Console.ReadLine() ?? "n";
    if (answer.ToLower XXXXXXXXXXXXXXXXXXXXXXXX)
    Environment.Exit(0);
}

private static void MenuOptions(string selectedOption)
{
    if (int.TryParse(selectedOption, out int option)) //Om detta är sant gör det som står i if satsen. kollar om det är en siffra.
    {
        switch (option)
        {
            case 1:
                CreateUserMenu();
                break;

            case 2:
                ListAllUSersMenu();
                break;

            case 0:
                ExitApplicationMenu();
                break;

            default:
                Console.WriteLine("Invalid option selected");
                Console.ReadKey();
                break;

        }

    }
}




}*/