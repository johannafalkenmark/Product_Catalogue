using Main_App.Models;
using Main_App.Services;
using Resources.Interfaces;
using System.Diagnostics;
using System.Xml.Linq;

namespace Resources.Tests.UnitTests;
// Testa för G: att produkter kan läggas till i listan och att listan innehåller rätt antal produkter efter att en ny produkt lagts till.
//Testa för VG: Att ta bort en produkt från listan; Att uppdatera en produkt.; Att spara och läsa in produkter från fil.
public class ProductServiceTests
{
    #region AddProductToList

    [Fact]
    public void AddProductToList__ShouldAddProductToListOfProducts__Return_ResponseResultSuccess_True()
    {
        //arrange
        
       var productService = new ProductService();
        Fruit fruit = new("Kiwi", "5", "2" );


        //Act - kör själva metoden

        ResponseResult<Fruit> result = productService.AddProductToList(fruit); 

        // Assert - utvärdering av resultatet

        Assert.True( result.Success );
    }



    //Fungerar EJ:
    [Fact]
    public void AddProductToList__ShouldNotAddProductToList_WhenProperiesAreEmpty__Return_ResponseResultSucceededFalse() 
    {
        var productService = new ProductService();
        Fruit fruit1 = new("", "", "");
        productService.AddProductToList(fruit1);

        ResponseResult<Fruit> result = productService.AddProductToList(fruit1);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }


    [Fact]

    public void AddDuplicateFruitNames__Should_NotAddFruitToList__ReturnFalse()

    {
        var productService = new ProductService();
        Fruit fruit2 = new("Kiwi", "3", "2");
        productService.AddProductToList(fruit2);

        ResponseResult<Fruit> result = productService.AddProductToList(fruit2);

        Assert.False( result.Success );

    }


    [Fact]
    public void SaveProductToFile__ShouldSaveProductToFile__Return_ResponseResultSuccess_True()
    {
      

        var productService = new ProductService();
        Fruit fruit = new("Banan", "5", "2");

        ResponseResult<Fruit> result = productService.SaveProductsToFile();

        Assert.True(result.Success);
    }

    [Fact]
    public void DeleteProductFromList__ShouldDeleteProductFromListOfProducts__Return_ResponseResultSuccess_True()
    {

    }

    #endregion
}