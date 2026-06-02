using CommunityToolkit.Mvvm.ComponentModel;

namespace Antyzakupoholik.Infrastructure;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title;
}