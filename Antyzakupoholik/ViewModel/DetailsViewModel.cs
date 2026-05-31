using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antyzakupoholik.ViewModel;

[QueryProperty("Text","Text")]

    public partial class DetailsViewModel : ObservableObject
    {
    [ObservableProperty]
    string text;
    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    }

