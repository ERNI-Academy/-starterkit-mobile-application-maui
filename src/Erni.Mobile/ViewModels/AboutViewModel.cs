using Erni.Mobile.Services.Configuration;
using Erni.Mobile.Services.Logging;
using CommunityToolkit.Mvvm.Input;

namespace Erni.Mobile.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    public AboutViewModel(ILoggingService loggingService, IApplicationSettingsService applicationSettingsService)
        : base(loggingService, applicationSettingsService)
    {
        Title = "About";
    }

    [RelayCommand]
    public async Task Browse()
    {
        await Browser.OpenAsync("https://dotnet.microsoft.com/en-us/apps/maui");
    }
}
