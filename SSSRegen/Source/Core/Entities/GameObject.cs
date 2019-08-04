using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;

namespace SSSRegen.Source.Core.Entities
{
    public abstract class GameObject : IGameObject
    {
        public virtual bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float MovementSpeed { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds => new Rectangle((Position.X - Size.X / 2).ToInt(), (Position.Y - Size.Y / 2).ToInt(), (int) Size.X, (int) Size.Y);

        public abstract void Initialize();

        public abstract void Update(IGameTime gameTime);

        public abstract void Draw(IGameTime gameTime);
    }
}