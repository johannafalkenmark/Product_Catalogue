﻿//Skapa klass som heter Product
//egenskaper namn, pris
//produkten ska få automatiskt unikt ID
//Skapa en lista av produkter för att lagra produkterna List < Product >




namespace Main_App.Models;


public class Product
{


    public string Name { get; set; } = null!;
    public string Price { get; set; } = null!; //öppna upp denna och lägg till någon typ av justering

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string CategoryId { get; set; } = null!; 



    public Product(string _name, string _price,  string _categoryId) //Detta är konstruktorn så att jag kan fylla i direkt i parentesen när jag skapar en produkt
    {
        Name = _name;
        Price = _price;
        CategoryId = _categoryId;
        //har ej med id då det ska genereras automatiskt
    }
}
