using Erni.Mobile.ViewModels;

namespace Erni.Mobile.Views;

public partial class ItemsPage : ContentPage
{
    ItemsViewModel _viewModel;

    public ItemsPage(ItemsViewModel itemsViewModel)
    {
		InitializeComponent();
        BindingContext = _viewModel = itemsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}