using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class NullPhysicsComponent : IPhysicsComponent
    {
        public void Initialize(IGameObject player)
        {
        }

        public void Update(IGameObject player, GameTime gameTime)
        {
        }
    }
}