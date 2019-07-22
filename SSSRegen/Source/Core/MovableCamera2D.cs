using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Core
{
    //http://www.david-amador.com/2009/10/xna-camera-2d-with-zoom-and-rotation/

    public class MovableCamera2D : Camera2D, IMovableCamera
    {
        private readonly GameContext _gameContext;
        private Vector2 _position;

        public MovableCamera2D(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public override Matrix Transform =>
            Matrix.CreateTranslation(_position.X, _position.Y, 0) *
            Matrix.CreateRotationZ(Rotation) *
            Matrix.CreateScale(Zoom, Zoom, 1) *
            Matrix.CreateTranslation(_gameContext.ScreenBounds.Width / 2, _gameContext.ScreenBounds.Height / 2, 0);

        public void Move(Vector2 delta)
        {
            _position += delta;
        }
    }
}