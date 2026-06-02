namespace Antyzakupoholik.Models;

public class MonthlyArchive
{
    public DateTime ArchiveDate { get; set; }

    public decimal SpendingLimit { get; set; }

    public decimal TotalSpent { get; set; }

    public List<Expense> Expenses { get; set; }
        = new();
}