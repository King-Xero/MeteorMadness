using System;
using Microsoft.Xna.Framework.Audio;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameSoundEffect : ISoundEffect, IDisposable
    {
        private readonly SoundEffectInstance _soundEffectInstance;

        public GameSoundEffect(SoundEffectInstance soundEffectInstance)
        {
            _soundEffectInstance = soundEffectInstance ?? throw new ArgumentNullException(nameof(soundEffectInstance));
        }

        public void Play(bool isLooping = false)
        {
            _soundEffectInstance.IsLooped = isLooping;
            _soundEffectInstance.Play();
        }

        public void Play(float volume, bool isLooping = false)
        {
            SetVolume(volume);
            Play(isLooping);
        }

        public void Play(float volume, float pitch, float pan, bool isLooping = false)
        {
            _soundEffectInstance.Pitch = pitch;
            _soundEffectInstance.Pan = pan;
            Play(volume, isLooping);
        }

        public void Pause()
        {
            if (_soundEffectInstance.State == SoundState.Playing)
            {
                _soundEffectInstance.Pause();
            }
        }

        public void Resume()
        {
            if (_soundEffectInstance.State == SoundState.Paused)
            {
                _soundEffectInstance.Resume();
            }
        }

        public void Stop()
        {
            if (_soundEffectInstance.State != SoundState.Stopped)
            {
                _soundEffectInstance.Stop();
            }
        }

        public void SetVolume(float volume)
        {
            if (volume < 0 || volume > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(volume));
            }

            _soundEffectInstance.Volume = volume;
        }

        public event EventHandler<GameSoundEffectDisposedEventArgs> OnDisposed = delegate { };

        public void Dispose()
        {
            OnDisposed.Invoke(this, new GameSoundEffectDisposedEventArgs(this));
            _soundEffectInstance.Dispose();
        }
    }
}