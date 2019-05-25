using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObject
    {
        bool Enabled { get; set; }
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}