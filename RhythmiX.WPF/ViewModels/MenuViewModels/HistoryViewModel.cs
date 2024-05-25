﻿using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels.MenuViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private List<Track> _historyTracks;

        private int count;

        private string countText;
        public string CountText
        {
            get => countText;
            set
            {
                countText = value;
                OnPropertyChanged(nameof(CountText));
            }
        }

        private bool hasTracks;
        public bool HasTracks
        {
            get => hasTracks;
            set
            {
                hasTracks = value;
                OnPropertyChanged(nameof(HasTracks));
            }
        }

        private ObservableCollection<TrackDto> historyTrackDtos;
        public ObservableCollection<TrackDto> HistoryTrackDtos
        {
            get => historyTrackDtos;
            set
            {
                historyTrackDtos = value;
                OnPropertyChanged(nameof(HistoryTrackDtos));
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoadContent;
        public HistoryViewModel(User user)
        {
            LoadContent = new LoadHistoryContentCommand(this, user);
            LoadContent.Execute(null);
        }

        public void UpdateContent(IEnumerable<Track> historyTracks)
        {
            _historyTracks = historyTracks.ToList();

            count = historyTracks.ToList().Count;
            HasTracks = count > 0;
            CountText = $"{count} {(count == 1 ? "song" : "songs")}";
            HistoryTrackDtos = new ObservableCollection<TrackDto>(historyTracks.Select(t => new TrackDto(t)));
        }
    }
}
