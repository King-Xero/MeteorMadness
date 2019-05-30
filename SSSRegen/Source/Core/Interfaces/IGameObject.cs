using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        float HorizontalVelocity { get; set; }
        float VerticalVelocity { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle Bounds { get; }
        void Initialize();
        void Update();
        void Draw(GameTime gameTime);
    }
}