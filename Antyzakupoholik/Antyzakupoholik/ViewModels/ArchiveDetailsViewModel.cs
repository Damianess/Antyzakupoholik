using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Antyzakupoholik.Models;
using Antyzakupoholik.Services;
using Antyzakupoholik.Infrastructure;

namespace Antyzakupoholik.ViewModels;

public partial class ArchiveDetailsViewModel
    : BaseViewModel
{
    private readonly MonthlyArchive _archive;

    private readonly IFirebaseService _firebase;

    public string MonthName =>
        _archive.ArchiveDate.ToString("MMMM yyyy");

    public decimal SpendingLimit =>
        _archive.SpendingLimit;

    public decimal TotalSpent =>
        _archive.TotalSpent;

    public ObservableCollection<Expense>
        Expenses
    { get; } = new();

    public ArchiveDetailsViewModel(
        MonthlyArchive archive)
    {
        _archive = archive;

        _firebase =
            DependencyContainer.Resolve<IFirebaseService>();

        foreach (var expense in archive.Expenses)
        {
            Expenses.Add(expense);
        }
    }

    [RelayCommand]
    private async Task Restore()
    {
        bool answer =
            await Application.Current.MainPage
            .DisplayAlert(
                "Przywróć archiwum",
                $"Przywrócić archiwum {MonthName}?",
                "Tak",
                "Nie");

        if (!answer)
            return;

        await _firebase
            .RestoreArchiveAsync(_archive);

        await Application.Current.MainPage
            .DisplayAlert(
                "Sukces",
                "Archiwum zostało przywrócone.",
                "OK");

        await Application.Current.MainPage
            .Navigation.PopToRootAsync();
    }
}