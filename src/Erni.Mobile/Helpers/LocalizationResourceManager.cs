﻿using Erni.Mobile.Extensions;
using Erni.Mobile.Resources;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Erni.Mobile.Helpers;

internal class LocalizationResourceManager : INotifyPropertyChanged
{
    private const string LanguageKey = nameof(LanguageKey);

    public static LocalizationResourceManager Instance { get; } = new LocalizationResourceManager();

    private LocalizationResourceManager()
    {
        var languageName = Preferences.Get(LanguageKey, CurrentCulture.TwoLetterISOLanguageName);
        if (languageName == null)
        {
            Preferences.Set(LanguageKey, CurrentCulture.TwoLetterISOLanguageName);
            languageName = CurrentCulture.TwoLetterISOLanguageName;
        }
        var culture = new CultureInfo(languageName);
        SetCulture(culture).GetAwaiter().GetResult();
    }

    public string this[string text]
    {
        get
        {
            return AppResources.ResourceManager.GetString(text, AppResources.Culture);
        }
    }

    public async Task SetCulture(CultureInfo language)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Thread.CurrentThread.CurrentUICulture = language;
            Thread.CurrentThread.CurrentCulture = language;
            CultureInfo.DefaultThreadCurrentCulture = language;
            CultureInfo.DefaultThreadCurrentUICulture = language;
            AppResources.Culture = language;
            Preferences.Set(LanguageKey, language.TwoLetterISOLanguageName);
            App.Current.MainPage = new MainPage();
        });

        Invalidate();
    }

    public string GetValue(string text, string ResourceId)
    {
        ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
        return resourceManager.GetString(text, CultureInfo.CurrentCulture);
    }

    public CultureInfo CurrentCulture => AppResources.Culture ?? Thread.CurrentThread.CurrentUICulture;

    public event PropertyChangedEventHandler PropertyChanged;

    public void Invalidate()
    {
        try
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        catch
        {
            //Ignore exception
        }
    }
}

