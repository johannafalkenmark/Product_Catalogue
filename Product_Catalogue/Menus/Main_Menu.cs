// Här har vi själva menyn.
//kan vara internal. är bara i det här projektet.

using System;
using Main_App.Services;
namespace Main_App.Menus;

    public class Main_Menu //BEhöver man menu vara en klass?
    {
    public static void MainMenu() //Sätter som static då den kan börja köras direkt?
    {
        Console.Clear();
        Console.WriteLine("1. Create New Product");

        Console.WriteLine("2. Show list of all Products");

        Console.WriteLine("3. Update existing product ");

        Console.WriteLine("4. Remove product ");

        Console.WriteLine("0. Exit");

        Console.Write("Enter an option: ");



        MenuService.MenuOptions(Console.ReadLine() ?? ""); //Skapat metod för detta i Menu service

    }
}










