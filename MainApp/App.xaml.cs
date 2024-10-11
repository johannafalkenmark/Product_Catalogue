
using Main_App.Services;
using MainApp.ViewModels;
using MainApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;
using System.Windows;

namespace MainApp;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    private void ConfigureServices(IServiceCollection services)
    {
     //   services.AddSingleton<IProductService, ProductService>();
       // services.AddSingleton<IFileService>(new IFileService());

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>();

        services.AddSingleton<OverviewViewModel>();
        services.AddSingleton<OverviewView>();

        services.AddSingleton<CreateViewModel>();
        services.AddSingleton<CreateView>();

        services.AddSingleton<EditViewModel>();
        services.AddSingleton<EditView>();

    }
}
