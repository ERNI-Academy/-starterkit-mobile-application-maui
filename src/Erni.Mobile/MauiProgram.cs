using Erni.Mobile.Helpers;
using Erni.Mobile.Platforms;
using Erni.Mobile.Services;
using Erni.Mobile.Services.Configuration;
using Erni.Mobile.Services.Logging;
using Erni.Mobile.ViewModels;
using Erni.Mobile.Views;

namespace Erni.Mobile;

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
                fonts.AddFont("fa-brands-400.ttf", "FAB");
                fonts.AddFont("fa-regular-400.ttf", "FAR");
                fonts.AddFont("fa-solid-900.ttf", "FAS");
                fonts.AddFont("GlyphIcons.ttf", "GlyphIcons");
            });
        builder.Services.AddLocalization();
        builder.Services.AddTransient<IConfigurationFileProvider, ConfigurationFileProvider>();
        builder.Services.AddTransient<IApplicationSettingsService, ApplicationSettingsService>();

        if (ApplicationMode.UseDebugLogging)
        {
            builder.Services.AddTransient<MockDataStore>();
            builder.Services.AddTransient<ILoggingService, MockLoggingService>();
        }
        else
        {
            builder.Services.AddTransient<MockDataStore>();
            builder.Services.AddTransient<ILoggingService, AppCenterLoggingService>();
        }
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddSingleton<AboutViewModel>();
        builder.Services.AddSingleton<ChangeLanguagePage>();
        builder.Services.AddSingleton<ChangeLanguageViewModel>();
        builder.Services.AddTransient<ItemDetailPage>();
        builder.Services.AddTransient<ItemDetailViewModel>();
        builder.Services.AddTransient<ItemsPage>();
        builder.Services.AddTransient<ItemsViewModel>();
        builder.Services.AddTransient<NewItemPage>();
        builder.Services.AddTransient<NewItemViewModel>();
        return builder.Build();
    }
}
