using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils;

namespace SSSRegen.Source.GameComponents.Physics
{
    public class PlayerPhysics : IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;

        public PlayerPhysics(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameObject player)
        {
            player.MovementDirection = Vector2.Zero;
            player.Speed = 500;

            ResetPosition(player);
        }

        public void Update(IGameObject player, IGameTime gameTime)
        {
            var playerPosition = player.Position;

            //ToDo Resolve collisions
            //If player collides with object, execute only what the player should do.
            //Other objects will handle themselves
            //_gameContext.Collisions.ResolveCollision(player);
            
            playerPosition += player.Speed * player.MovementDirection * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();

            playerPosition.X = MathHelper.Clamp(playerPosition.X, _gameContext.ScreenBounds.Left,
                _gameContext.ScreenBounds.Width - player.Bounds.Width);

            player.Position = playerPosition;
        }

        private void ResetPosition(IGameObject player)
        {
            var playerPosition = player.Position;

            playerPosition.X = _gameContext.ScreenBounds.Center.X - player.Bounds.Width;
            playerPosition.Y = _gameContext.ScreenBounds.Height - player.Bounds.Height - 10;

            player.Position = playerPosition;
        }
    }
}