using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using Resources.Services;

namespace MainApp.ViewModels;

public partial class OverviewViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService<Fruit, Fruit> _productService;
    // LÄGG TILL _categoryService
   private readonly CategoryService _categoryService;


    public OverviewViewModel(IServiceProvider serviceProvider, IProductService<Fruit, Fruit> productService, CategoryService categoryService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
        _categoryService = categoryService;
        // OCH ÄVEN HÄR

        UpdateFruitList();
    }

    [ObservableProperty] //LÄGGER IN CATEGORY HÄR(?)
    private Category category = new("", "");
    
    [ObservableProperty]
    private ObservableCollection<Fruit> productList = [];

    [RelayCommand]
    public void Add()
    {
        
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CreateViewModel>();
    }

    [RelayCommand]
    public void Edit(Fruit fruit)
    {
       

        var editViewModel = _serviceProvider.GetRequiredService<EditViewModel>();

        var fruittoedit = new Fruit(fruit.Name, fruit.Price, fruit.CategoryId); 
        fruittoedit.Id = fruit.Id; 
        editViewModel.Fruit = fruittoedit; 


        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = editViewModel;
    }

    [RelayCommand]
    public void Delete(string id)
    {
        try
        {
            _productService.DeleteProduct(id);
            UpdateFruitList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
    }


    public void UpdateFruitList()
    {
        try
        {
            ProductList.Clear();
            
            var categories = _categoryService.ShowAllCategories().Result;
            var fruits = _productService.GetAllProducts().Result;

            if (fruits != null && categories != null)
            {

                foreach (Fruit fruit in fruits)
                {

                    // Plocka hem kategori typ
                    var category = categories.First(category => category.Id == fruit.CategoryId);
                    // Lägg till det på ditt fruit objekt
                    if (category != null)
                    {
                        fruit.CategoryName = category.Name;
                    }

                    ProductList.Add(fruit);

                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
    }




}
