using System;
using System.IO;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Gst;
using Stream = System.IO.Stream;
using Avalonia.Media.Imaging;

namespace Zplayer.Views;

public partial class MainView : UserControl
{
    private Element pipeline;
    private bool isPlaying = false;
    private string path;
    private Timer timer;
    public MainView()
    {
        InitializeComponent();
        InitializeGStreamer();
        InitializeTimer();
    }

    private void InitializeTimer()
    {
        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(IncrementTimer);
        timer.Interval = 1000;
    }
    private void InitializeGStreamer()
    {
        Application.Init();
    }

    private void IncrementTimer(object sender, ElapsedEventArgs e)
    {
        
    }
    private async void OpenFile(object? sender, RoutedEventArgs e)
    {
        var window = this.GetVisualRoot() as Window;
        var dialog = new OpenFileDialog();
        dialog.Title = "Otwórz plik mp3";
        string[] result = await dialog.ShowAsync(window);
        if (result != null)
        {
            path = result[0];
            TagLib.File file = TagLib.File.Create(result[0]);
            double length = Double.Parse(file.Properties.Duration.TotalSeconds.ToString());
            Slider.Maximum = Math.Round(length);
            if (file.Tag.Title != null)
            {
                title.Text = file.Tag.Title;
            }
            if (file.Tag.FirstAlbumArtist != null)
            {
                author.Text = file.Tag.FirstAlbumArtist;
            }
            if (file.Tag.Pictures.Length > 0)
            {
                var data = file.Tag.Pictures[0].Data.Data;
                using var stream = new MemoryStream(data);
                Bitmap bitmap = new Bitmap(stream);
                cover.Source = bitmap;
            }
        }
    }

    private void toggleSongState(object? sender, RoutedEventArgs e)
    {
        if (!isPlaying)
        {
            Console.WriteLine("Play");
            try
            {
                string fileUri = new System.Uri(path).AbsoluteUri;
                pipeline = Parse.Launch($"playbin uri=\"{fileUri}\"");
                pipeline.SetState(State.Playing);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            isPlaying = true;
        }
        else
        {
            pipeline.SetState(State.Paused);
            isPlaying = false;
        }
    }
}