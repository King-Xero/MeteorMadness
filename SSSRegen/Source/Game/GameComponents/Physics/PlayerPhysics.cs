using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
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
            
            ResetPosition(player);
        }

        public void Update(IGameObject player, IGameTime gameTime)
        {
            var playerPosition = player.Position;

            player.Rotation += MathHelper.ToRadians(player.RotationSpeed) * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();

            //Rotation needs a 90 degree offset for upright sprites
            player.MovementDirection = new Vector2(
                Math.Cos(MathHelper.ToRadians(90) - player.Rotation).ToFloat(),
                -Math.Sin(MathHelper.ToRadians(90) - player.Rotation).ToFloat());

            playerPosition += player.MovementSpeed * player.MovementDirection * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();


            playerPosition = KeepPlayerInScreenBounds(player, playerPosition);


            player.Position = playerPosition;
        }

        //If the player moves off a side of the screen, wrap around to just off the opposite side of the screen
        //Position is offset by 1 so that the player isn't technically off screen
        private Vector2 KeepPlayerInScreenBounds(IGameObject player, Vector2 playerPosition)
        {
            if (playerPosition.X + player.Size.X < _gameContext.GameGraphics.ScreenBounds.Left)
            {
                playerPosition.X = _gameContext.GameGraphics.ScreenBounds.Right - 1;
            }

            if (playerPosition.X > _gameContext.GameGraphics.ScreenBounds.Right)
            {
                playerPosition.X = _gameContext.GameGraphics.ScreenBounds.Left - player.Size.X + 1;
            }

            if (playerPosition.Y + player.Size.Y < _gameContext.GameGraphics.ScreenBounds.Top)
            {
                playerPosition.Y = _gameContext.GameGraphics.ScreenBounds.Bottom - 1;
            }

            if (playerPosition.Y > _gameContext.GameGraphics.ScreenBounds.Bottom)
            {
                playerPosition.Y = _gameContext.GameGraphics.ScreenBounds.Top - player.Size.Y + 1;
            }

            return playerPosition;
        }

        //Reset the player position to the center of the screen
        private void ResetPosition(IGameObject player)
        {
            var playerPosition = player.Position;

            playerPosition.X = _gameContext.GameGraphics.ScreenBounds.Center.X - player.Origin.X;
            playerPosition.Y = _gameContext.GameGraphics.ScreenBounds.Center.Y - player.Origin.Y;

            player.Position = playerPosition;
        }
    }
}