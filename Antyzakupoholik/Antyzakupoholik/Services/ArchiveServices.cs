using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Models;

namespace Antyzakupoholik.Services;

public class ArchiveService
    : IArchiveService
{
    private readonly IFirebaseService
        _firebase;

    public ArchiveService()
    {
        _firebase =
            DependencyContainer
                .Resolve<IFirebaseService>();
    }

    public async Task ArchiveCurrentMonthAsync()
    {
        var expenses =
            await _firebase
                .GetExpensesAsync();

        var settings =
            await _firebase
                .GetSettingsAsync();

        var archive =
            new MonthlyArchive
            {
                ArchiveDate =
                    DateTime.Now,

                SpendingLimit =
                    settings.SpendingLimit,

                TotalSpent =
                    expenses.Sum(
                        x => x.Amount),

                Expenses =
                    expenses
            };

        await _firebase
            .SaveArchiveAsync(
                archive);
    }
}