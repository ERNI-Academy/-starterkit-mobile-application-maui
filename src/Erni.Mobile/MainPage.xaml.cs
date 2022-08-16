using Erni.Mobile.Views;

namespace Erni.Mobile;

public partial class MainPage : Shell
{
	public MainPage()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
		Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
	}
}

