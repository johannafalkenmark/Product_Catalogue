using Main_App.Models;
using Moq;
using Resources.Interfaces;
using Resources.Services;
using Newtonsoft.Json;

namespace Resources.Tests.UnitTests;

public class ProductServiceTests
{
    private readonly ProductService _productService;
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly List<Fruit> _testProductList;

    public ProductServiceTests()
    {
        _fileServiceMock = new Mock<IFileService>();
        
        _testProductList = new List<Fruit>
        {
            new Fruit("Äpple", "10", "1"),
            new Fruit("Banan", "5", "2")
        };

        _productService = new ProductService(_fileServiceMock.Object);
    }

    #region Add And Delete ProductToList

    [Fact]
    public void AddProductToList__ShouldAddProductToListOfProducts__Return_ResponseResultSuccess_True()
    {
        //Arrange   
        Fruit fruit = new("Honungsmelon", "5", "2" );


        //Act 
        ResponseResult<Fruit> result = _productService.AddProductToList(fruit); 

        // Assert 
        Assert.True( result.Success );
    }

    [Fact]

    public void EnterDuplicateFruitNames__Should_NotAddFruitToList__ReturnFalse()

    {
        //Arrange 
        Fruit fruit2 = new("Äpple", "3", "2");

        //Act 
        _productService.AddProductToList(fruit2);

        ResponseResult<Fruit> result = _productService.AddProductToList(fruit2);

        // Assert 
        Assert.False( result.Success );

    }

    [Fact]
    public void DeleteProductFromList__ShouldDeleteProductFromListOfProducts__Return_ResponseResultSuccess_True()
    {

        //Arrange
        var _name = "Apelsin";
        var _price = "5";
        var Id = "1";

        Fruit fruit = new Fruit(_name, _price, Id);

        //Act
        ResponseResult<Fruit> result = _productService.DeleteProduct("1");

        //Assert
        Assert.True(result.Success);
        Assert.Equal("We have found and deleted product.", result.Message);

    }
    #endregion

    #region Save And Load From File
    [Fact]
    public void SaveProductToFile__ShouldSaveProductToFile__Return_ResponseResultSuccess_True()
    {
      
        //Arrange
        Fruit fruit = new("Apelsin", "5", "2");

        //Act
        ResponseResult<Fruit> result = _productService.SaveProductsToFile();

        //Assert
        Assert.True(result.Success);
    }

    [Fact]
    public void AddProductsFromFile_ShouldLoadProducts_ResultSuccess_True()
    {
        
        //Arrange
        var json = JsonConvert.SerializeObject(_testProductList);

        //Act
        _fileServiceMock.Setup(x => x.GetFromFile()).Returns(new ResponseResult<string> { Success = true, Result = json });

       
        var result = _productService.AddProductsFromFile();

     //Assert
        Assert.True(result.Success);
     
    }

        #endregion
    }