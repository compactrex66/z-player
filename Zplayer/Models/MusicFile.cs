using System;
using System.IO;
using Avalonia.Media.Imaging;

namespace Zplayer.Models;

public class MusicFile
{
    public string FilePath { get; private set; }

    public string GetFileName() {
        return Path.GetFileNameWithoutExtension(FilePath);
    }

    private string? _title;
    public string? Title {
        get {
            if (string.IsNullOrEmpty(_title)) {
                return GetFileName();
            }
            return _title;
        }
        set {
            _title = value;
        }
    }
    private string? _album;
    public string? Album {
        get {
            if (string.IsNullOrEmpty(_album)) {
                return "-";
            }
            return _album;
        }
        set {
            _album = value;
        }
    }
    private string? _artist;
    public string? Artist {
        get {
            if (string.IsNullOrEmpty(_artist)) {
                return "<Unknown>";
            }
            return _artist;
        }
        set {
            _title = value;
        }
    }
    private Bitmap? _cover;
    public Bitmap? Cover {
        get {
            return _cover;
        }
        private set {
            _cover = value;
        }
    }
    public readonly TimeSpan Duration;
    public MusicFile(string filePath, string? title, string? album, string? artist, Bitmap? cover, TimeSpan duration) {
        FilePath = filePath;
        _title = title;
        _album = album;
        _artist = artist;
        Cover = cover;
        Duration = duration;
    }

    public MusicFile(string path) {
        FilePath = path;
        TagLib.File file = TagLib.File.Create(path);
        _title = file.Tag.Title;
        _album = file.Tag.Album;
        _artist = file.Tag.FirstPerformer;
        Duration = file.Properties.Duration;
        if (file.Tag.Pictures != null && file.Tag.Pictures.Length > 0) {
            _cover = new Bitmap(new MemoryStream(file.Tag.Pictures[0].Data.Data));
        } else {
            _cover = null;
        }
    }
    public override string ToString() {
        return Title + " - " + Artist;
    }
}