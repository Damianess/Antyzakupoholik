using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace Antyzakupoholik.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel() 
        {
            Items = new ObservableCollection<string>();
        }
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(Text))
                return;
           Items.Add(Text);
            Text = string.Empty;
        }
        [RelayCommand]
        void Delete(string text)
        {
            if(Items.Contains(text))
            {
                Items.Remove(text);
            }
        }
        [RelayCommand]
        async Task TapCommand(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(Details)}?Text={s}");
        }
    }
}
