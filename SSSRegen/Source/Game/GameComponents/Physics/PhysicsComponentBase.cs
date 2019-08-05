using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Physics
{
    public class PhysicsComponentBase
    {
        private readonly GameContext _gameContext;

        public PhysicsComponentBase(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        //If the GameObject moves off a side of the screen, wrap around to just off the opposite side of the screen
        //Position is offset by 1 so that the GameObject isn't technically off screen
        protected Vector2 KeepGameObjectInScreenBounds(IGameObject gameObject, Vector2 position)
        {
            if (position.X + gameObject.Origin.X < _gameContext.GameGraphics.ScreenBounds.Left)
            {
                position.X = _gameContext.GameGraphics.ScreenBounds.Right - 1;
            }

            if (position.X > _gameContext.GameGraphics.ScreenBounds.Right)
            {
                position.X = _gameContext.GameGraphics.ScreenBounds.Left - gameObject.Origin.X + 1;
            }

            if (position.Y + gameObject.Origin.Y < _gameContext.GameGraphics.ScreenBounds.Top)
            {
                position.Y = _gameContext.GameGraphics.ScreenBounds.Bottom - 1;
            }

            if (position.Y > _gameContext.GameGraphics.ScreenBounds.Bottom)
            {
                position.Y = _gameContext.GameGraphics.ScreenBounds.Top - gameObject.Origin.Y + 1;
            }

            return position;
        }
    }
}