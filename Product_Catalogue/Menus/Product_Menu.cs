﻿using Main_App.Models;
using Resources.Interfaces;
using Resources.Services;
using System.Diagnostics;

namespace Main_App.Menus;

public class Product_Menu
{
    public IProductService<Fruit, Fruit> _productService = new ProductService();
    public CategoryService _categoryService = new CategoryService();

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
                    UpdateMenu();
                    break;

                case 4:
                    RemoveMenu();
                    break;

                case 5:
                    SaveToFileMenu();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;


                default:
                    Console.WriteLine("\n Invalid number/option selected, try again");
                    Console.ReadKey();
                    break;
            }
        }
        else
        {
            Console.WriteLine("\n Type a number 0-5");
            Console.ReadKey();         
        }
    }

 
    public void AddNewProductMenu()
    {
      
        Console.Clear();
        Console.WriteLine("---CREATING/ADDING FRUIT---");

        Console.Write("Enter name of Fruit: ");
        string productName = Console.ReadLine() ?? "";

        var findName = _productService.GetProductFromName(productName);
        try
        {
            if (findName.Success)
            {
                Console.WriteLine("Fruitname already exist try again");
                Console.Write("Enter name of fruit: ");
                productName = Console.ReadLine() ?? "";
            }
            Console.Write("Price of fruit: ");
            string productPrice = Console.ReadLine() ?? "";

            Console.Write("Category of fruit (Enter 1 = Local or 2 = Exotic): ");
            string productCategoryId = Console.ReadLine() ?? "";

            Console.Clear();
            Console.WriteLine($"You have entered: ");


            Console.WriteLine($"Name: {char.ToUpper(productName[0]) + productName.Substring(1)}");
            Console.WriteLine($"Price: {productPrice.Trim()} SEK ");


            var categories = _categoryService.ShowAllCategories().Result;

            if (categories != null)
            {
                var fruitCategory = categories.First(x => x.Id == productCategoryId);


                Console.WriteLine($"\nYour fruit is categorized as {fruitCategory.Name}.\n");
            }

                var product = new Fruit(productName, productPrice, productCategoryId);

                Console.WriteLine($"Product ID: {product.Id} \n");

                _productService.AddProductToList(product);
            
            }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }

    }
    public void ViewAllProductsMenu()
    {

        Console.Clear();
        Console.WriteLine("---LIST OF FRUITS--- \n");

        _productService.GetAllProducts();

        Console.WriteLine("Press Any key to continue.");
        Console.ReadKey();

    }

    public void UpdateMenu()
    {
        Console.Clear();
        Console.WriteLine("---UPDATE FRUIT---  \n ");

        Console.WriteLine("Enter product ID: ");
        var Id = Console.ReadLine() ?? "";

        var responseResult = _productService.GetProduct(Id);
        try
        {
            if (responseResult.Success == true && responseResult.Result != null)
            {

                var product = responseResult.Result;
                Console.Clear();
                Console.WriteLine($"We have found your fruit, press to view.");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine($"Update name or Price for \n");
                Console.WriteLine($"{product.Name}, {product.Price} SEK\n");

                Console.WriteLine($"\nPress Any key");

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine($"\n New Name:");
                product.Name = Console.ReadLine() ?? "";

                Console.WriteLine($"\n New Price:");
                product.Price = Console.ReadLine() ?? "";

                Console.WriteLine("Press Any key To view update.");
                Console.Clear();
                Console.WriteLine("---FRUIT HAVE BEEN UPDATED---");
                Console.WriteLine($"Updated Name: {product.Name} \n");
                Console.WriteLine($"Updated price: {product.Price} \n");

                Console.WriteLine("Press Any key to return to Main Menu");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("We have not found your fruit. \n Try Again");
                Console.ReadKey();
                UpdateMenu();

            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
    }

    private void RemoveMenu()
    {
        Console.Clear();
        Console.WriteLine("---DELETE FRUIT--- \n ");
        Console.Write("Enter product ID: ");
        var Id = Console.ReadLine() ?? "";

        var responseResult = _productService.GetProduct(Id);
        try
        {
            if (responseResult.Success == true && responseResult.Result != null)
            {
                var product = responseResult.Result;
                Console.Clear();

                Console.WriteLine($"Press to delete fruit \n");
                Console.WriteLine($"{product.Name}, {product.Price} SEK\n");

                Console.ReadKey();
                _productService.DeleteProduct(Id);
                Console.Clear();
                Console.WriteLine("Fruit has been deleted. \n Press for Main Menu.");
            }
            else
            {
                Console.WriteLine("We have not found your fruit. \n Try Again");
                Console.ReadKey();
                RemoveMenu();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
    } 

    public void SaveToFileMenu()
    {
        Console.Clear();
        Console.WriteLine("---SAVE TO FILE--- \n Your fruits have been saved to file. \n Press Any key to return to Main Menu.\n");
        
        _productService.SaveProductsToFile();

        Console.ReadKey();

    }

    static void ExitApplicationMenu()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? Enter y/n.");
            var answer = Console.ReadLine();
       
        if (answer?.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        Console.ReadKey();
        }
    }
