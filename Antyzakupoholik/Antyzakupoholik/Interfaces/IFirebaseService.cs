using Antyzakupoholik.Models;

public interface IFirebaseService
{
    Task<List<Expense>> GetExpensesAsync();

    Task AddExpenseAsync(Expense expense);

    Task DeleteExpenseAsync(string id);

    Task<AppSettings> GetSettingsAsync();

    Task SaveSettingsAsync(AppSettings settings);

    Task DeleteAllExpensesAsync();
    Task SaveArchiveAsync(
    MonthlyArchive archive);
    Task<List<MonthlyArchive>>
    GetArchivesAsync();
    Task RestoreArchiveAsync(
    MonthlyArchive archive);
}