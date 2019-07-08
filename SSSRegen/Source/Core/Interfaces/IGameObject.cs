using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        float Speed { get; set; }
        Vector2 MovementDirection { get; set; }
        Vector2 Size { get; set; }
        Rectangle Bounds { get; }
        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
    }
}