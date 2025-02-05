using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Timers;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Avalonia.Threading;
using Gst;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Zplayer.Models;

namespace Zplayer.Views;

public partial class MainView : UserControl
{
    private Element pipeline;
    private bool isPlaying = false;
    private string path;
    private DispatcherTimer _timer;
    private int secondsPassed = 0;
    public ObservableCollection<MusicFile> Playlist = new ObservableCollection<MusicFile>();
    public MainView()
    {
        InitializeComponent();
        InitializeGStreamer();
        InitializeTimer();
        pipeline = new Pipeline();
        PlaylistBox.ItemsSource = Playlist;
    }

    private void InitializeTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(1000);
        _timer.Tick += UpdateTimer;
    }
    private void InitializeGStreamer()
    {
        Application.Init();
    }

    private void UpdateTimer(object? sender, EventArgs e)
    {
        if (MySlider.Value + 1 < MySlider.Maximum)
        {
            MySlider.Value += 1;
            secondsPassed++;
            currentTime.Text = "" + secondsPassed / 60 + ":" + (secondsPassed % 60 < 10 ? "0" + secondsPassed % 60 : secondsPassed % 60);
        }
    }
    
    private async void OpenFile(object? sender, RoutedEventArgs e)
    {
        var window = this.GetVisualRoot() as Window;
        var dialog = new OpenFileDialog();
        dialog.Title = "Otwórz plik mp3";
        string[] result = await dialog.ShowAsync(window);
        if (result == null || result.Length < 1) 
        {
            return;
        }
        Playlist.Add(new MusicFile(result[0]));
    }

    private void resetSongState()
    {
        pipeline.SetState(State.Null);
        secondsPassed = 0;
        currentTime.Text = "0:00";
        MySlider.Value = 0;
        changePlayStateIcon.Source = new Bitmap(AssetLoader.Open(new System.Uri("avares://Zplayer/Assets/playIcon.ico")));
        _timer.Stop();
        isPlaying = false;
    }
    private void LoadSong(MusicFile song)
    {
        resetSongState();
        title.Text = song.Title;
        author.Text = song.Artist;
        cover.Source = song.Cover;
        maxTime.Text = song.Duration.Minutes + ":" + song.Duration.Seconds;
        MySlider.Maximum = song.Duration.TotalSeconds;
        try
        { 
            string fileUri = new System.Uri(song.FilePath).AbsoluteUri; 
            pipeline = Parse.Launch($"playbin uri=\"{fileUri}\"");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private void SongSelected(object? sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine(e);
        LoadSong((MusicFile)PlaylistBox.SelectedItem);
    }
    private void toggleSongState(object? sender, RoutedEventArgs e)
    {
        if (!isPlaying)
        {
            Console.WriteLine("Play playback");
            pipeline.SetState(State.Playing);
            isPlaying = true;
            _timer.Start();
            changePlayStateIcon.Source = new Bitmap(AssetLoader.Open(new System.Uri("avares://Zplayer/Assets/pauseIcon.png")));
        }
        else
        {
            Console.WriteLine("Stop playback");
            pipeline.SetState(State.Paused);
            isPlaying = false;
            _timer.Stop();
            changePlayStateIcon.Source = new Bitmap(AssetLoader.Open(new System.Uri("avares://Zplayer/Assets/playIcon.ico")));
        }
    }
}