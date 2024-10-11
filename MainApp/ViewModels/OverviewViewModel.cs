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

       var fruitsInProductService = _productService.GetAllProducts().Result;

        ProductList = new ObservableCollection<Fruit>(fruitsInProductService);
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
        _productService.CurrentFruit = fruit;
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditViewModel>();
    }

    [RelayCommand]
    public void Delete(string id)
    {
        _productService.DeleteProduct(id);

    }
 
}
