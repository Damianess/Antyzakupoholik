using CommunityToolkit.Maui;

using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Services;
using Antyzakupoholik.Interfaces;

namespace Antyzakupoholik;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        RegisterServices();

        return builder.Build();
    }

    private static void RegisterServices()
    {
        DependencyContainer.Register<IExpenseService>(
            new ExpenseService());
        DependencyContainer.Register<IFirebaseService>(
         new FirebaseService());
        DependencyContainer.Register<IArchiveService>(
        new ArchiveService());
            DependencyContainer.Register(
        new MonthlyResetService());
    }
}