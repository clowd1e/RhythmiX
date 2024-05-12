using RhythmiX.Storage.Entities;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace RhythmiX.WPF.Services
{
    public class MusicPlayer
    {
        private MediaPlayer _player;
        private List<Track> _tracks;
        private int currentTrackIndex;

        public MusicPlayer(List<Track> tracks)
        {
            _player = new MediaPlayer();
            _tracks = tracks;
        }

        public void Play()
        {
            if (_player.Source is null)
                _player.Open(new Uri($"../../../APICallResults/DownloadedMusic/{_tracks[currentTrackIndex].Name}/{_tracks[currentTrackIndex].Name}.mp3"));

            _player.Play();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void PlayNext()
        {
            _player.Stop();
            currentTrackIndex++;
            _player.Open(new Uri($"../../../APICallResults/DownloadedMusic/{_tracks[currentTrackIndex].Name}/{_tracks[currentTrackIndex].Name}.mp3"));
            _player.Play();
        }
    }
}
