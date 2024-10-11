
using Main_App.Models;
using Main_App.Services;
using MainApp.ViewModels;
using MainApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Resources.Interfaces;
using System.IO;
using System.Windows;

namespace MainApp;

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }
   
    private void ConfigureServices(IServiceCollection services)
    {
        //services.AddSingleton < IProductService<Fruit, Fruit>, ProductService>();
         services.AddSingleton<IProductService<Fruit, Fruit>>(new ProductService());

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>();

        services.AddSingleton<OverviewViewModel>();
        services.AddSingleton<OverviewView>();


        services.AddSingleton<CreateViewModel>();
        services.AddSingleton<CreateView>();

        services.AddSingleton<EditViewModel>();
        services.AddSingleton<EditView>();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

      //  var productService = ServiceProvider.GetService<ProductService>();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>();
        mainWindow.Show(); 
        base.OnStartup(e);
    }
}
