using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using NewClient.Services;
using NewClient.Services.Interface;

namespace NewClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
        
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddSingleton<IIngridientService, IngridientService>();
        builder.Services.AddSingleton<IDishService, DishService>();
        builder.Services.AddSingleton<IDishSizeService, DishSizeService>();
        builder.Services.AddSingleton<IOrderService, OrderService>();
        builder.Services.AddSingleton<CartService>();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<NotificationService>();
        
        builder.Logging.AddDebug();

        return builder.Build();
    }
}