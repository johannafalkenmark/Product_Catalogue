using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Main_App.Services;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace MainApp.ViewModels;

public partial class OverviewViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService<Fruit, Fruit> _productService;

    public OverviewViewModel(IServiceProvider serviceProvider, IProductService<Fruit, Fruit> productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
        UpdateFruitList();
    }

    [ObservableProperty] //LÄGGER IN CATEGORY HÄR
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
            foreach (Fruit fruit in _productService.GetAllProducts().Result)
            {
                ProductList.Add(fruit);

            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR: {ex.Message}");
        }
    }




}
