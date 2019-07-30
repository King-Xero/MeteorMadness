using System;
using SSSRegen.Source.Core.Audio;

namespace SSSRegen.Source.Core.Interfaces.Audio
{
    public interface ISoundEffect
    {
        void Play(bool isLooping);
        void Play(float volume, bool isLooping);
        void Play(float volume, float pitch, float pan, bool isLooping);
        void Pause();
        void Resume();
        void Stop();
        void SetVolume(float volume);
        event EventHandler<GameSoundEffectDisposedEventArgs> OnDisposed;
    }

    public class GameSoundEffectDisposedEventArgs : EventArgs
    {
        public readonly GameSoundEffect SoundEffect;

        public GameSoundEffectDisposedEventArgs(GameSoundEffect gameSoundEffect)
        {
            SoundEffect = gameSoundEffect;
        }
    }
}