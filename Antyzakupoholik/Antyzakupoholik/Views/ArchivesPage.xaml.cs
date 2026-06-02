using Antyzakupoholik.ViewModels;

namespace Antyzakupoholik.Views;

public partial class ArchivesPage : ContentPage
{
    private readonly ArchivesViewModel _viewModel;

    public ArchivesPage()
    {
        InitializeComponent();

        _viewModel =
            new ArchivesViewModel();

        BindingContext =
            _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadAsync();
    }
}