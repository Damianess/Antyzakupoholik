using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Services;

namespace Antyzakupoholik;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Task.Run(async () =>
        {
            var reset =
                DependencyContainer
                    .Resolve<MonthlyResetService>();

            await reset.CheckMonthAsync();
        });
        MainPage = new NavigationPage(
            new MainPage());
    }
}