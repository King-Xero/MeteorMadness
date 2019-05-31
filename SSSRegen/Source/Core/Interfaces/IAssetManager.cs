using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IAssetManager
    {
        void LoadTexture(string name, string fileName);
        Texture2D GetTexture(string name);

        void LoadFont(string name, string fileName);
        SpriteFont GetFont(string name);
    }
}
