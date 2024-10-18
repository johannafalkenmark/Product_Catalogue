namespace Main_App.Menus;

public class Main_Menu
{
    Product_Menu _productMenu = new();

    public void MainMenu() 
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        Console.WriteLine("1.".PadRight(10) + "Create New Product");

        Console.WriteLine("2.".PadRight(10) + "Show list of all Products");

        Console.WriteLine("3.".PadRight(10) + "Update existing product ");

        Console.WriteLine("4.".PadRight(10) + "Remove product ");

        Console.WriteLine("5.".PadRight(10) + "Save products to file ");

        Console.WriteLine("0.".PadRight(10) + "Exit");

        Console.Write("\n Enter an option (0-5): ");

     _productMenu.MenuOptions(Console.ReadLine() ?? ""); 

    }
}










