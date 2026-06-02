using Antyzakupoholik.Models;

namespace Antyzakupoholik.Interfaces;

public interface IExpenseService
{
    List<Expense> GetAll();

    void Add(Expense expense);

    void Delete(string id);

    decimal GetTotalSpent();
}