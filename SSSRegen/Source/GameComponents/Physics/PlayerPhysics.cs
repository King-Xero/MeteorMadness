using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class PlayerPhysics : IPhysicsComponent
    {
        private readonly GameContext _gameContext;

        public PlayerPhysics(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameObject player)
        {
            player.HorizontalVelocity = 0;
        }

        public void Update(IGameObject player)
        {
            var playerPosition = player.Position;

            playerPosition.X += player.HorizontalVelocity;

            //ToDo Resolve collisions
            //If player collides with object, execute only what the player should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(player);
            
            if (player.Position.X <= _gameContext.ScreenBounds.Left)
            {
                playerPosition.X = _gameContext.ScreenBounds.Left;
            }
            if (player.Position.X >= _gameContext.ScreenBounds.Width - player.Bounds.Width)
            {
                
                playerPosition.X = _gameContext.ScreenBounds.Width - player.Bounds.Width;
            }

            player.Position = playerPosition;
        }
    }
}