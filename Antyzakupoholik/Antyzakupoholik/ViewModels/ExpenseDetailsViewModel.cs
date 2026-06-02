using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Antyzakupoholik.Models;
using Antyzakupoholik.Services;
using Antyzakupoholik.Infrastructure;

namespace Antyzakupoholik.ViewModels;

public partial class ExpenseDetailsViewModel : ObservableObject
{
    private readonly IFirebaseService _firebase;
    private readonly Expense _expense;
    private readonly MainViewModel _mainVm;

    public string Name => _expense.Name;
    public string Description => _expense.Description;
    public decimal Amount => _expense.Amount;

    public ExpenseDetailsViewModel(
    Expense expense,
    MainViewModel mainViewModel)
    {
        _expense = expense;
        _mainVm = mainViewModel;

        _firebase =
            DependencyContainer.Resolve<IFirebaseService>();
    }
    [RelayCommand]
    private async Task Delete()
    {
        await _firebase
    .DeleteExpenseAsync(
        _expense.Id);

        _mainVm.RefreshAsync();

        await Application.Current.MainPage.Navigation.PopAsync();
    }
}