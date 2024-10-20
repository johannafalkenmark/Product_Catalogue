using Main_App.Menus;
using Main_App.Models;
using Resources.Interfaces;

Main_Menu _mainMenu = new();

while (true)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    _mainMenu.MainMenu();
    Console.ReadKey();
}



