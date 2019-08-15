using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class MeteorPhysicsComponent : PhysicsComponentBase, IComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Vector2 _movementDirection;

        public MeteorPhysicsComponent(GameContext gameContext, Random random) : base(gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public void Initialize(IGameObject meteor)
        {
            Reset(meteor);
        }

        public void Update(IGameObject meteor, IGameTime gameTime)
        {
            //Move the meteor
            meteor.Position += Vector2.Multiply(_movementDirection, meteor.MovementSpeed * 0.8f * gameTime.ElapsedGameTime.TotalSeconds.ToFloat());

            meteor.Position = KeepGameObjectInScreenBounds(meteor, meteor.Position);
        }

        private void Reset(IGameObject meteor)
        {
            meteor.IsActive = false;

            //Set random movement direction
            _movementDirection = new Vector2(_random.Next(-10, 11),_random.Next(-10, 11));
            _movementDirection.Normalize();

            //ToDo Read from constant into a meteor
            meteor.MovementSpeed = 100;

            var meteorPosition = meteor.Position;

            //Random coordinate in the left or right 25% of the screen
            meteorPosition.X = _random.RandomInRanges(new[]
            {
                new Tuple<int, int>(0, _gameContext.GameGraphics.ScreenBounds.Width / 4),
                new Tuple<int, int>((_gameContext.GameGraphics.ScreenBounds.Width / 4) * 3, _gameContext.GameGraphics.ScreenBounds.Width),
            });

            //Random coordinate in the top or bottom 25% of the screen
            meteorPosition.Y = _random.RandomInRanges(new[]
            {
                new Tuple<int, int>(0, _gameContext.GameGraphics.ScreenBounds.Height / 4),
                new Tuple<int, int>((_gameContext.GameGraphics.ScreenBounds.Height / 4) * 3, _gameContext.GameGraphics.ScreenBounds.Height),
            });

            meteor.Position = meteorPosition;
        }
    }
}