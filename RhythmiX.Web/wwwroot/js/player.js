const elms = ['trackProgress', 'trackKnob', 'playBack', 'play', 'pause', 'playNext', 'trackName', 'trackArtist', 'trackTime', 'trackDuration', 'sliderBar', 'trackList'];
elms.forEach(function (elm) {
    window[elm] = document.getElementById(elm);
});

let playlist = trackViewModel.TrackDtos;
let currentTrackIndex = trackViewModel.CurrentTrackIndex;

let Player = function (playlist, index) {
    this.playlist = playlist;
    this.index = index;

    trackName.innerHTML = playlist[index].TrackName;
    trackArtist.innerHTML = playlist[index].ArtistName;
    trackTime.innerHTML = '0:00';
    trackDuration.innerHTML = ' / ' + playlist[index].Duration;
}

Player.prototype = {
    play: function (index) {
        let self = this;
        let track;

        index = typeof index === 'number' ? index : self.index;
        let data = self.playlist[index];
        self.index = index;

        if (data.howl) {
            track = data.howl;
        } else {
            track = data.howl = new Howl({
                src: [`/APICallResults/DownloadedTracks/${data.TrackName}/${data.TrackName}.mp3`],
                html5: true,
                onplay: function () {
                    trackDuration.innerHTML = ' / ' + self.formatTime(Math.round(track.duration()));

                    requestAnimationFrame(self.step.bind(self));

                    play.style.display = 'none';
                    pause.style.display = 'flex';
                },
                onload: function () {
                    
                },
                onend: function () {
                    let nextTrackId = (currentTrackIndex + 1) >= playlist.length ? playlist[0].Id : playlist[currentTrackIndex + 1].Id;
                    window.location.href = `/MusicPlayer/${trackViewModel.Title}?userId=${trackViewModel.UserId}&trackId=${nextTrackId}`;
                },
                onpause: function () {

                },
                onstop: function () {

                },
                onseek: function () {
                    requestAnimationFrame(self.step.bind(self));
                }
            });
        }

        track.play();

        trackName.innerHTML = data.TrackName;
        trackArtist.innerHTML = data.ArtistName;
        trackDuration.innerHTML = ' / ' + data.Duration;

        if (track.state() === 'loaded') {
            play.style.display = 'none';
            pause.style.display = 'flex';
        } else {
            pause.style.display = 'none';
            play.style.display = 'flex';
        }
    },

    pause: function () {
        let self = this;

        let data = self.playlist[self.index];
        let track = data.howl;

        track.pause();

        pause.style.display = 'none';
        play.style.display = 'flex';
    },

    skip: function (direction) {
        let self = this;

        let index = self.index;
        if (direction === 'back') {
            index--;
            if (index < 0) {
                index = self.playlist.length - 1;
            }
        } else {
            index++;
            if (index >= self.playlist.length) {
                index = 0;
            }
        }

        self.skipTo(index);
    },

    skipTo: function (index) {
        let self = this;

        if (self.playlist[self.index].howl) {
            self.playlist[self.index].howl.stop();
        }

        trackProgress.style.width = '0%';
        trackKnob.style.left = '0%';

        self.play(index);
    },

    volume: function (val) {
        let self = this;

        Howler.volume(val);


    },

    seek: function (per) {
        let self = this;

        let data = self.playlist[self.index];
        let track = data.howl;
        let seek = track.duration() * per;

        track.seek(seek);
    },

    step: function () {
        let self = this;

        let data = self.playlist[self.index];
        let track = data.howl;

        let seek = track.seek() || 0;
        trackTime.innerHTML = self.formatTime(Math.round(seek));

        let per = (((seek / track.duration()) * 100) || 0) + '%';
        trackProgress.style.width = per;
        trackKnob.style.left = per;

        if (track.playing()) {
            requestAnimationFrame(self.step.bind(self));
        }
    },

    formatTime: function (secs) {
        let minutes = Math.floor(secs / 60) || 0;
        let seconds = (secs - minutes * 60) || 0;

        return minutes + ':' + (seconds < 10 ? '0' : '') + seconds;
    }
}

let player = new Player(playlist, currentTrackIndex);

window.addEventListener('load', function () {
    player.play();
})

play.addEventListener('click', function () {
    player.play();
})

pause.addEventListener('click', function () {
    player.pause();
})

playNext.addEventListener('click', function () {
    player.skip('next');
})

playBack.addEventListener('click', function () {
    player.skip('back');
})

sliderBar.addEventListener('click', function (event) {
    player.seek(event.clientX / window.innerWidth);
});