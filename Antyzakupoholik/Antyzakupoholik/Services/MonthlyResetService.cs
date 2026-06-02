using Antyzakupoholik.Infrastructure;

namespace Antyzakupoholik.Services;

public class MonthlyResetService
{
    private readonly IFirebaseService
        _firebase;

    private readonly IArchiveService
        _archive;

    public MonthlyResetService()
    {
        _firebase =
            DependencyContainer
                .Resolve<IFirebaseService>();

        _archive =
            DependencyContainer
                .Resolve<IArchiveService>();
    }

    public async Task CheckMonthAsync()
    {
        var settings =
            await _firebase
                .GetSettingsAsync();

        var now =
            DateTime.Now;

        if (settings.LastArchiveMonth
                == now.Month
            &&
            settings.LastArchiveYear
                == now.Year)
        {
            return;
        }

        await _archive
            .ArchiveCurrentMonthAsync();

        await _firebase
            .DeleteAllExpensesAsync();

        settings.CurrentSpent = 0;

        settings.SpendingLimit = 0;

        settings.LastArchiveMonth =
            now.Month;

        settings.LastArchiveYear =
            now.Year;

        await _firebase
            .SaveSettingsAsync(
                settings);
    }
}