
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2.ViewModel;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject
    {
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    async Task Edit()
    {
        // This could navigate to an edit page, enable a form, or just show a message
        await Shell.Current.DisplayAlert("Edit", $"Editing: {Text}", "OK");

        // Or navigate to another page:
        // await Shell.Current.GoToAsync(nameof(EditPage));
    }

}

