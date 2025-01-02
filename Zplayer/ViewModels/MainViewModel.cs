using CommunityToolkit.Mvvm.ComponentModel;

namespace Zplayer.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
