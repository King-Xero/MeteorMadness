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
            ResetPosition(player);
        }

        public void Update(IGameObject player)
        {
            var playerPosition = player.Position;

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

            playerPosition.X += player.HorizontalVelocity;

            player.Position = playerPosition;
        }

        private void ResetPosition(IGameObject player)
        {
            var playerPosition = player.Position;

            playerPosition.X = _gameContext.ScreenBounds.Width / 2 - player.Bounds.Width;
            playerPosition.Y = _gameContext.ScreenBounds.Height - player.Bounds.Height - 10;

            player.Position = playerPosition;

            //ToDo change starting position depending on number of players
            //if (_playerIndex == PlayerIndex.One)
            //{
            //    _position.X = _screenBounds.Width / 3; //Player ones's _position along the bottom of the screen
            //}
            //else
            //{
            //    _position.X = (int)(_screenBounds.Width / 1.5); //Player two's _position along the bottom of the screen
            //}
        }
    }
}