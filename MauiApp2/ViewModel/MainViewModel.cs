using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace MauiApp2.ViewModel;

public partial class MainViewModel : ObservableObject
{

    IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        items = new ObservableCollection<string>();
        text = string.Empty;
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        { 
        await Shell.Current.DisplayAlert("Error", "No Internet Connection", "OK");
            return;
                }

            items.Add(Text);
        text = string.Empty;
    }
    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");

    }
}


        
 