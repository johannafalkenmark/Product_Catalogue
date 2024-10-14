using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Main_App.Services;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;
using System.Collections.ObjectModel;

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
        // _productService.CurrentFruit = fruit; // 1,53 i filmen. bytte yt till den nedan då fungearde det!

        var editViewModel = _serviceProvider.GetRequiredService<EditViewModel>();
        editViewModel.Fruit = fruit; 

        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = editViewModel;
    }

    [RelayCommand]
    public void Delete(string id)
    {
        _productService.DeleteProduct(id);
        UpdateFruitList();

    }


    public void UpdateFruitList()
    {
        ProductList.Clear();
        foreach(var fruit in _productService.GetAllProducts().Result)
        {
            ProductList.Add(fruit);
        }
    }

}
