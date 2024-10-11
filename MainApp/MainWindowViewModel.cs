using CommunityToolkit.Mvvm.ComponentModel;
using MainApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace MainApp;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    
public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<OverviewViewModel>(); 
    }
    [ObservableProperty]
    private ObservableObject currentViewModel;

}
