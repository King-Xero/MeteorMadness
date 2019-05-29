using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameObject : IGameObject
    {
        public bool IsEnabled { get; set; }
        public Vector2 Position { get; set; }

        public virtual void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}