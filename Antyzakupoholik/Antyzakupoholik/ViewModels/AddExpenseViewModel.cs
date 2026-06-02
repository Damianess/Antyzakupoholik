using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Models;
using Antyzakupoholik.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Xml.Linq;

namespace Antyzakupoholik.ViewModels;

public partial class AddExpenseViewModel : BaseViewModel
{
    private readonly IFirebaseService
    _firebase;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private decimal amount;

    public AddExpenseViewModel()
    {
        _firebase =
            DependencyContainer.Resolve<IFirebaseService>();
    }

    [RelayCommand]
    private async Task Save()
    {
        var expense = new Expense
        {
            Name = Name,
            Description = Description,
            Amount = Amount
        };

        await _firebase
            .AddExpenseAsync(expense);

        await Application.Current.MainPage.Navigation.PopAsync();
    }
}