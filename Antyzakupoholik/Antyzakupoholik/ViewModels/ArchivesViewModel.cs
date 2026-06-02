using Antyzakupoholik.Infrastructure;
using Antyzakupoholik.Models;
using Antyzakupoholik.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

public partial class ArchivesViewModel
    : BaseViewModel
{
    private readonly IFirebaseService
        _firebase;

    public ObservableCollection<MonthlyArchive> Archives { get; }
        = new();

    public ArchivesViewModel()
    {
        _firebase =
            DependencyContainer
                .Resolve<IFirebaseService>();
    }

    public async Task LoadAsync()
    {
        Archives.Clear();

        var archives =
            await _firebase
                .GetArchivesAsync();

        foreach (var archive in archives)
        {
            Archives.Add(archive);
        }
    }
    [RelayCommand]
    private async Task OpenArchive(
    MonthlyArchive archive)
    {
        if (archive == null)
            return;

        await Application.Current.MainPage
            .Navigation.PushAsync(
                new ArchiveDetailsPage(
                    archive));
    }
}