using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Camera;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Core.Camera
{
    public class TrackingCamera2D : Camera2D, ITrackingCamera
    {
        private readonly GameContext _gameContext;
        private Matrix _transform;

        public override Matrix Transform => _transform;

        public TrackingCamera2D(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }
    
        public void Follow(IGameObject target)
        {
            var position = Matrix.CreateTranslation(-target.Position.X - (target.Size.X / 2), -target.Position.Y - (target.Size.Y / 2), 0);

            var rotation = Matrix.CreateRotationZ(Rotation);

            var zoom = Matrix.CreateScale(Zoom, Zoom, 1);

            var offset = Matrix.CreateTranslation(_gameContext.GameGraphics.ScreenBounds.Width / 2, _gameContext.GameGraphics.ScreenBounds.Height / 2, 0);

            _transform = position *
                         rotation *
                         zoom *
                         offset;
        }
    }
}