using Antyzakupoholik.ViewModels;

namespace Antyzakupoholik.Views;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage()
    {
        InitializeComponent();

        BindingContext =
            new AddExpenseViewModel();
    }
}