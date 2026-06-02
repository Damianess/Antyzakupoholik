using Antyzakupoholik.Interfaces;
using Antyzakupoholik.Models;

namespace Antyzakupoholik.Services;

public class ExpenseService : IExpenseService
{
    private readonly List<Expense> _expenses = new();

    public List<Expense> GetAll()
    {
        return _expenses;
    }

    public void Add(Expense expense)
    {
        _expenses.Add(expense);
    }

    public void Delete(string id)
    {
        var expense = _expenses.FirstOrDefault(x => x.Id == id);

        if (expense != null)
        {
            _expenses.Remove(expense);
        }
    }

    public decimal GetTotalSpent()
    {
        return _expenses.Sum(x => x.Amount);
    }
}