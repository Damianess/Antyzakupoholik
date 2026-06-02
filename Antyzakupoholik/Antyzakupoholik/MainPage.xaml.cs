using Antyzakupoholik.ViewModels;

namespace Antyzakupoholik;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MainViewModel vm)
            await vm.RefreshAsync();
    }
}