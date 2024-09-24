// Här har vi själva menyn.
//kan vara internal. är bara i det här projektet.

using System;
using Main_App.Models;
using Main_App.Services;
namespace Main_App.Menus;

    public class Main_Menu
{



    MenuService _menuService = new MenuService();
 
    public void MainMenu() 
    {
        Console.Clear();
        Console.WriteLine("1. Create New Product");

        Console.WriteLine("2. Show list of all Products");

        Console.WriteLine("3. Update existing product ");

        Console.WriteLine("4. Remove product ");

        Console.WriteLine("0. Exit");

        Console.Write("Enter an option: ");



        _menuService.MenuOptions(Console.ReadLine() ?? ""); 

    }
}










