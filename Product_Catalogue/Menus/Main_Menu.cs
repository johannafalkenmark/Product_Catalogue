// Här har vi själva menyn.
//kan vara internal. är bara i det här projektet.

using System;
using Main_App.Models;
using Resources.Services;
namespace Main_App.Menus;

public class Main_Menu
{



    MenuService _menuService = new MenuService();
 
    public void MainMenu() 
    {
        Console.Clear();
        Console.WriteLine("1.".PadRight(10) + "Create New Product");

        Console.WriteLine("2.".PadRight(10) + "Show list of all Products");

        Console.WriteLine("3.".PadRight(10) + "Update existing product ");

        Console.WriteLine("4.".PadRight(10) + "Remove product ");

        Console.WriteLine("0.".PadRight(10) + "Exit");

        Console.Write("\n Enter an option (0-4): ");



        _menuService.MenuOptions(Console.ReadLine() ?? ""); 

    }
}










