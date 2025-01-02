using Avalonia.Controls;
using Gst;

namespace Zplayer.Views;

public partial class MainWindow : Window
{
    private Element pipeline;
    private bool isPlaying;
    public MainWindow()
    {
        InitializeComponent();
        Application.Init();
    }
}