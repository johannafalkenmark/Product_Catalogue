using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;

namespace MainApp.ViewModels;

public partial class EditViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService<Fruit, Fruit> _productService;

    public EditViewModel(IServiceProvider serviceProvider, IProductService<Fruit, Fruit> productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
    }


    [ObservableProperty]

    private Fruit fruit = new("", "", "");

    [RelayCommand]

    public void Save()
    {
        
        _productService.UpdateFruit(Fruit);
     // _productService.AddProductToList(Fruit);
        
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        var overViewViewModel = _serviceProvider.GetService<OverviewViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();

        overViewViewModel.UpdateFruitList();
    }

    [RelayCommand]
    public void Exit()
    {

        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();
    }

}
