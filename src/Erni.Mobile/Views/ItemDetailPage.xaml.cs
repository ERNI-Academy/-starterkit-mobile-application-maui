using Erni.Mobile.ViewModels;

namespace Erni.Mobile.Views;

public partial class ItemDetailPage : ContentPage
{
	public ItemDetailPage(ItemDetailViewModel itemDetailViewModel)
	{
		InitializeComponent();
		BindingContext = itemDetailViewModel;
	}
}