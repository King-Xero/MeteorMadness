using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace SSSRegen.Source.Core.Interfaces.Audio
{
    public interface IGameAudioManager
    {
        void Initialize();
        void Update();

        void PlayMusic(Song song, bool isLooping);
        void PlayMusic(Song song, float volume, bool isLooping);
        void PauseMusic();
        void ResumeMusic();
        void StopMusic();
        void SetMusicVolume(float volume);

        ISoundEffect CreateSoundEffect(SoundEffect soundEffect);
        void PlaySoundEffect(SoundEffect soundEffect);
        void SetSoundEffectMasterVolume(float volume);

        void PauseAllAudio();
        void ResumeAllAudio();
    }
}