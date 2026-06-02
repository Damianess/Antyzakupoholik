namespace Antyzakupoholik.Models;

public class AppSettings
{
    public decimal SpendingLimit { get; set; }

    public decimal CurrentSpent { get; set; }

    public int LastArchiveMonth { get; set; }

    public int LastArchiveYear { get; set; }
}