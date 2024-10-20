using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Resources.Services;
using Microsoft.Extensions.DependencyInjection;
using MySqlX.XDevAPI.Common;
using Resources.Interfaces;




namespace MainApp.ViewModels;

public partial class CreateViewModel(IServiceProvider serviceProvider, IProductService<Fruit, Fruit> productService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IProductService<Fruit, Fruit> _productService = productService;
    
    
    [ObservableProperty]
   private Fruit fruit = new("", "", "");

    [ObservableProperty]
    private string? invalidName; 

    [RelayCommand]
    public void Save() 
    {
        
       _productService.AddProductToList(Fruit);

        
            //lägga till if sats här if (result == Resources.Models.ResponseResult.Success) 1:36 i film 1,41 DEN LYCKAS EJ HITTA TILL MODELS DÄEÖFR GÅR DET EJ
            //else visa invalid name! som nu är mappat ocg föreberett i vyn


            var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            var overViewViewModel = _serviceProvider.GetService<OverviewViewModel>();

            overViewViewModel?.UpdateFruitList();

            viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();

            Fruit = new("", "", "");

        
        //Else  InvalidName == "Name already exists";
        
    }


    [RelayCommand]
    public void Cancel() 
    {
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();
    }

}
