//Program filen så lite som möjligt så rent som möjligt. starta upp programmet här. sen ha olika kataloger för resten av programmet
//Kan vara internal. är bara i det här projektet

using Main_App.Interfaces;
using Main_App.Menus;
using Main_App.Models;
using Main_App.Services;

public static IProductService<Product, Product> _productService = new ProductService(@"C:\Projects School\Product_Catalogue\Product_Catalogue\Products.json");


Main_Menu.MainMenu();

Console.ReadKey();

/*



// while(true) { 

//}


*/