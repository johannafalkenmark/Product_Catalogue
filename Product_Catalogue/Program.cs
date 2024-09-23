//Program filen så lite som möjligt så rent som möjligt. starta upp programmet här. sen ha olika kataloger för resten av programmet
//Kan vara internal. är bara i det här projektet

using Main_App.Interfaces;
using Main_App.Menus;
using Main_App.Models;
using Main_App.Services;


//Skall denna vara här?
//FRÅGA summerad. HUR får jag in metod från product service ini product menu. de har båda interfaces.
 IProductService<Product, Product> _productService = new ProductService(@"C:\Projects School\Product_Catalogue\Product_Catalogue\Products.json");


Main_Menu.MainMenu();

Console.ReadKey();

/*



// while(true) { 

//}


*/