using Antyzakupoholik.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
namespace Antyzakupoholik;

public partial class Details : ContentPage
{
    public Details(DetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}