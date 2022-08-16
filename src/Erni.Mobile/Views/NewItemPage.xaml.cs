using Erni.Mobile.Models;
using Erni.Mobile.ViewModels;

namespace Erni.Mobile.Views;

public partial class NewItemPage : ContentPage
{
    public Item Item { get; set; }

    public NewItemPage(NewItemViewModel newItemViewModel)
    {
        InitializeComponent();
        BindingContext = newItemViewModel;
    }
}