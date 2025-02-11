﻿using Erni.Mobile.Helpers;
using Erni.Mobile.Models;
using Erni.Mobile.Resources;
using Erni.Mobile.Services.Configuration;
using Erni.Mobile.Services.Logging;
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.Input;

namespace Erni.Mobile.ViewModels;

public partial class ChangeLanguageViewModel : BaseViewModel
{
    public ObservableCollection<Language> Languages { get; set; }

    public Language SelectedLanguage { get; set; }

    public ChangeLanguageViewModel(ILoggingService loggingService, IApplicationSettingsService applicationSettingsService)
        : base(loggingService, applicationSettingsService)
    {
        LoadLanguage();
    }

    void LoadLanguage()
    {
        Languages = new ObservableCollection<Language>()
        {
            {new Language(AppResources.English, "en") },
            {new Language(AppResources.Filipino, "fil") },
            {new Language(AppResources.German, "de") },
            {new Language(AppResources.Romanian, "ro")} ,
            {new Language(AppResources.Slovak, "sk")} ,
            {new Language(AppResources.Spanish, "es") }
        };
        SelectedLanguage = Languages.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Instance.CurrentCulture.ThreeLetterISOLanguageName);
    }

    [RelayCommand]
    private async Task ChangeLanguage()
    {
        if (SelectedLanguage != null)
        {
            await LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
            LoadLanguage();
            await App.Current.MainPage.DisplayAlert(AppResources.LanguageChanged, "", AppResources.Done);
        }
    }
}
