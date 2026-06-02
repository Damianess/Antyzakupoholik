using Antyzakupoholik.Models;
using Antyzakupoholik.ViewModels;

namespace Antyzakupoholik.Views;

public partial class ExpenseDetailsPage : ContentPage
{
    public ExpenseDetailsPage(
        Expense expense,
        MainViewModel vm)
    {
        InitializeComponent();

        BindingContext =
            new ExpenseDetailsViewModel(
                expense,
                vm);
    }
}