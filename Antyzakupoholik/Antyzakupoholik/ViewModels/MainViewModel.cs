using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Antyzakupoholik.Models;
using Antyzakupoholik.Services;
using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Views;

namespace Antyzakupoholik.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IFirebaseService _firebase;
    public ObservableCollection<Expense> Expenses { get; }
        = new();

    [ObservableProperty]
    private decimal spendingLimit = 2000;

    [ObservableProperty]
    private decimal currentSpent;

    public bool IsLimitExceeded =>
        CurrentSpent > SpendingLimit;

    public MainViewModel()
    {
        Title = "Antyzakupoholik";
        _firebase =
    DependencyContainer.Resolve<IFirebaseService>();
    }

    [RelayCommand]
    private async Task AddExpense()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AddExpensePage());
    }

    [RelayCommand]
    private async Task OpenExpense(Expense expense)
    {
        await Application.Current.MainPage.Navigation.PushAsync(
            new ExpenseDetailsPage(expense, this));
    }

    public async Task LoadDataAsync()
    {
        Expenses.Clear();

        var expenses =
            await _firebase.GetExpensesAsync();

        foreach (var expense in expenses)
        {
            Expenses.Add(expense);
        }

        var settings =
            await _firebase.GetSettingsAsync();

        SpendingLimit =
            settings.SpendingLimit;

        CurrentSpent =
            Expenses.Sum(x => x.Amount);

        OnPropertyChanged(
            nameof(IsLimitExceeded));
    }

    public async Task RefreshAsync()
    {
        await LoadDataAsync();
    }
    [RelayCommand]
    private async Task SetLimit()
    {
        string result =
            await Application.Current.MainPage
            .DisplayPromptAsync(
                "Limit wydatków",
                "Podaj limit miesięczny:");

        if (string.IsNullOrWhiteSpace(result))
            return;

        if (!decimal.TryParse(result, out var limit))
            return;

        var settings =
            await _firebase.GetSettingsAsync();

        settings.SpendingLimit = limit;

        await _firebase.SaveSettingsAsync(settings);

        SpendingLimit = limit;

        OnPropertyChanged(nameof(IsLimitExceeded));
    }
    [RelayCommand]
    private async Task OpenArchives()
    {
        await Application.Current.MainPage
            .Navigation.PushAsync(
                new ArchivesPage());
    }

}