using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Main_App.Models;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;





namespace MainApp.ViewModels;

public partial class CreateViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService<Fruit, Fruit> _productService;

 
    public CreateViewModel(IServiceProvider serviceProvider, IProductService<Fruit, Fruit> productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
    }

    [ObservableProperty]
    private Fruit fruit = new("", "", ""); //här det som ska in när man skriver in i konsoll product menu
   
    [RelayCommand]
    public void Save() 
    {
    _productService.AddProductToList(Fruit);
    
       //lägga till if sats här? if (result == Resources.Models.ResponseResult.Success) 1:36 i film 1,41
       
         //navigera tillbaka:
         var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
         var overViewViewModel = _serviceProvider.GetService<OverviewViewModel>();
        
         overViewViewModel.UpdateFruitList();

        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();

    }


    [RelayCommand]
    public void Cancel() //hette delete förut
    {
        var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        viewModel.CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>();
    }

}
