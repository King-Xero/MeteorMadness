using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class PlayerPhysicsComponent : PhysicsComponentBase, IComponent<IPlayer>
    {
        private readonly GameContext _gameContext;
        //ToDo Move to game constants
        private float _friction = 0.5f;
        private Vector2 _thrustingVelocity;
        private Vector2 _movementDirection;

        public PlayerPhysicsComponent(GameContext gameContext) : base(gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IPlayer player)
        {
            _movementDirection = Vector2.Zero;
            
            ResetPosition(player);
        }

        public void Update(IPlayer player, IGameTime gameTime)
        {
            //Calculate rotation using rotation speed set in PlayerInputComponent
            player.Rotation += MathHelper.ToRadians(player.RotationSpeed) * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();

            //Only update movement direction if accelerating. Allows player to rotate while "drifting".
            if (player.IsAccelerating)
            {
                //Rotation needs a 90 degree offset for upright sprites
                _movementDirection = new Vector2(
                    Math.Cos(MathHelper.ToRadians(90) - player.Rotation).ToFloat(),
                    -Math.Sin(MathHelper.ToRadians(90) - player.Rotation).ToFloat());
            }
            
            //Calculate thrusting velocity. Based off of acceleration friction calculation here: http://community.monogame.net/t/acceleration-and-friction-in-2d-games/9319
            _thrustingVelocity += _movementDirection * player.MovementSpeed - _friction * _thrustingVelocity * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();

            player.Position += _thrustingVelocity * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();
            
            player.Position = KeepGameObjectInScreenBounds(player, player.Position);
        }

        //Reset the player position to the center of the screen
        private void ResetPosition(IGameObject player)
        {
            player.Position = _gameContext.GameGraphics.ScreenBounds.Center.ToVector2();
        }
    }
}