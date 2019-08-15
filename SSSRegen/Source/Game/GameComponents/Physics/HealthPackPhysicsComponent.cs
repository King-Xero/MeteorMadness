using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class HealthPackPhysicsComponent : PhysicsComponentBase, IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Vector2 _movementDirection;

        public HealthPackPhysicsComponent(GameContext gameContext, Random random) : base(gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject healthPack)
        {
            Reset(healthPack);
        }

        public void Update(IGameObject healthPack, IGameTime gameTime)
        {
            //Move the healthPack
            healthPack.Position += Vector2.Multiply(_movementDirection, healthPack.MovementSpeed * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            healthPack.Position = KeepGameObjectInScreenBounds(healthPack, healthPack.Position);
        }

        private void Reset(IGameObject healthPack)
        {
            healthPack.IsActive = false;

            //Set random movement direction
            _movementDirection = new Vector2(_random.Next(-10, 11), _random.Next(-10, 11));
            _movementDirection.Normalize();

            //ToDo Read from constant
            healthPack.MovementSpeed = 10;

            healthPack.Position = _gameContext.GameGraphics.ScreenBounds.Center.ToVector2();
        }
    }
}