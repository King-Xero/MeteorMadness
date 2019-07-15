using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IAssetManager
    {
        void LoadTexture(string name, string fileName);
        Texture2D GetTexture(string name);

        void LoadFont(string name, string fileName);
        SpriteFont GetFont(string name);

        void LoadSong(string name, string fileName);
        Song GetSong(string name);

        void LoadSoundEffect(string name, string fileName);
        SoundEffect GetSoundEffect(string name);
    }
}
