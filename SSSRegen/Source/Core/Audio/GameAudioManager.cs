using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using SSSRegen.Source.Core.Interfaces.Audio;

namespace SSSRegen.Source.Core.Audio
{
    public class GameAudioManager : IGameAudioManager
    {
        private List<ISoundEffect> _soundEffectInstances;
        private List<SoundEffectInstance> _soundEffectOneShots;

        public void Initialize()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = false;
            
            _soundEffectInstances = new List<ISoundEffect>();
            _soundEffectOneShots = new List<SoundEffectInstance>();
        }

        public void Update()
        {
            var newOneShotList = new List<SoundEffectInstance>();

            foreach (var oneShot in _soundEffectOneShots)
            {
                if (oneShot.State != SoundState.Stopped)
                {
                    newOneShotList.Add(oneShot);
                }
            }

            _soundEffectOneShots = newOneShotList;
        }

        public void PlayMusic(Song song, bool isLooping)
        {
            MediaPlayer.IsRepeating = isLooping;
            MediaPlayer.Play(song);
        }

        public void PlayMusic(Song song, float volume, bool isLooping)
        {
            MediaPlayer.IsRepeating = isLooping;
            SetMusicVolume(volume);
            MediaPlayer.Play(song);
        }
        
        public void PauseMusic()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
        }

        public void ResumeMusic()
        {
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
        }

        public void StopMusic()
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }
        }

        public void SetMusicVolume(float volume)
        {
            if (volume < 0 || volume > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(volume));
            }
            MediaPlayer.Volume = volume;
        }

        public ISoundEffect CreateSoundEffect(SoundEffect soundEffect)
        {
            var sfx = new GameSoundEffect(soundEffect.CreateInstance());
            sfx.OnDisposed += SfxOnOnDisposed;
            _soundEffectInstances.Add(sfx);

            return sfx;
        }

        public void PlaySoundEffect(SoundEffect soundEffect)
        {
            var sfx = soundEffect.CreateInstance();
            sfx.Play();
            _soundEffectOneShots.Add(sfx);
        }

        public void SetSoundEffectMasterVolume(float volume)
        {
            if (volume < 0 || volume > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(volume));
            }

            SoundEffect.MasterVolume = volume;
        }

        public void PauseAllAudio()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }

            foreach (var soundEffectInstance in _soundEffectInstances)
            {
                soundEffectInstance.Pause();
            }

            foreach (var soundEffectOneShot in _soundEffectOneShots)
            {
                if (soundEffectOneShot.State == SoundState.Playing)
                {
                    soundEffectOneShot.Pause();
                }
            }
        }

        public void ResumeAllAudio()
        {
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }

            foreach (var soundEffectInstance in _soundEffectInstances)
            {
                soundEffectInstance.Resume();
            }

            foreach (var soundEffectOneShot in _soundEffectOneShots)
            {
                if (soundEffectOneShot.State == SoundState.Paused)
                {
                    soundEffectOneShot.Resume();
                }
            }
        }

        private void SfxOnOnDisposed(object sender, GameSoundEffectDisposedEventArgs e)
        {
            _soundEffectInstances.Remove(e.SoundEffect);
        }
    }
}