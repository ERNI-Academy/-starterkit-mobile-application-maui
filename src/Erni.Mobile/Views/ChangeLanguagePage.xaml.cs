using Erni.Mobile.ViewModels;

namespace Erni.Mobile.Views;

public partial class ChangeLanguagePage : ContentPage
{
	public ChangeLanguagePage(ChangeLanguageViewModel changeLanguageViewModel)
	{
		InitializeComponent();
		BindingContext = changeLanguageViewModel;
	}
}