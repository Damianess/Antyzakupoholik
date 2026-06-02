using Antyzakupoholik.Models;
using Antyzakupoholik.ViewModels;

namespace Antyzakupoholik.Views;

public partial class ArchiveDetailsPage
    : ContentPage
{
    public ArchiveDetailsPage(
        MonthlyArchive archive)
    {
        InitializeComponent();

        BindingContext =
            new ArchiveDetailsViewModel(
                archive);
    }
}