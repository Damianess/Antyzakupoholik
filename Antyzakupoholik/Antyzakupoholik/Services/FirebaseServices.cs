using Firebase.Database;
using Firebase.Database.Query;
using Antyzakupoholik.Services;
using Antyzakupoholik.Models;

namespace Antyzakupoholik.Services;

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseClient _client;

    private const string UserId = "default";

    public FirebaseService()
    {
        _client = new FirebaseClient(
            "https://antyzakupoholik-default-rtdb.europe-west1.firebasedatabase.app/");
    }

    public async Task<List<Expense>> GetExpensesAsync()
    {
        var result = await _client
            .Child("users")
            .Child(UserId)
            .Child("expenses")
            .OnceAsync<Expense>();

        return result
            .Select(x =>
            {
                x.Object.Id = x.Key;
                return x.Object;
            })
            .ToList();
    }

    public async Task AddExpenseAsync(
        Expense expense)
    {
        await _client
            .Child("users")
            .Child(UserId)
            .Child("expenses")
            .PostAsync(expense);
    }

    public async Task DeleteExpenseAsync(
        string id)
    {
        await _client
            .Child("users")
            .Child(UserId)
            .Child("expenses")
            .Child(id)
            .DeleteAsync();
    }

    public async Task<AppSettings> GetSettingsAsync()
    {
        return await _client
            .Child("users")
            .Child(UserId)
            .Child("settings")
            .OnceSingleAsync<AppSettings>()
            ?? new AppSettings();
    }

    public async Task SaveSettingsAsync(
        AppSettings settings)
    {
        await _client
            .Child("users")
            .Child(UserId)
            .Child("settings")
            .PutAsync(settings);
    }

    public async Task DeleteAllExpensesAsync()
    {
        await _client
            .Child("users")
            .Child(UserId)
            .Child("expenses")
            .DeleteAsync();
    }
    public async Task SaveArchiveAsync(
    MonthlyArchive archive)
    {
        string archiveId =
            archive.ArchiveDate
                .ToString("yyyy_MM");

        await _client
            .Child("users")
            .Child(UserId)
            .Child("archives")
            .Child(archiveId)
            .PutAsync(archive);
    }
    public async Task<List<MonthlyArchive>> GetArchivesAsync()
    {
        var result = await _client
            .Child("users")
            .Child(UserId)
            .Child("archives")
            .OnceAsync<MonthlyArchive>();

        return result
            .Select(x => x.Object)
            .ToList();
    }
    public async Task RestoreArchiveAsync(
    MonthlyArchive archive)
    {
        await DeleteAllExpensesAsync();

        foreach (var expense in archive.Expenses)
        {
            await AddExpenseAsync(expense);
        }

        var settings =
            await GetSettingsAsync();

        settings.SpendingLimit =
            archive.SpendingLimit;

        settings.CurrentSpent =
            archive.TotalSpent;

        await SaveSettingsAsync(
            settings);
    }
}