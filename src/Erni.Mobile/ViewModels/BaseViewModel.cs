using CommunityToolkit.Mvvm.ComponentModel;
using Erni.Mobile.Models;
using Erni.Mobile.Services;
using Erni.Mobile.Services.Configuration;
using Erni.Mobile.Services.Logging;

namespace Erni.Mobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
    public readonly ILoggingService LoggingService;
    public readonly IApplicationSettingsService ApplicationSettingsService;

    public BaseViewModel(ILoggingService loggingService, IApplicationSettingsService applicationSettingsService)
    {
        this.LoggingService = loggingService;
        this.ApplicationSettingsService = applicationSettingsService;
    }

    [ObservableProperty]
    bool isBusy = false;

    [ObservableProperty]
    string title = string.Empty;
}
