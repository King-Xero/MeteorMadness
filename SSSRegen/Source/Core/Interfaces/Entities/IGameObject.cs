using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Interfaces.Entities
{
    public interface IGameObject
    {
        bool IsActive { get; set; }
        Vector2 Position { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
        float MovementSpeed { get; set; }
        float RotationSpeed { get; set; }
        //ToDo Make movement direction private to physics component
        Vector2 MovementDirection { get; set; }
        Vector2 Size { get; set; }
        Rectangle Bounds { get; }
        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
    }
}