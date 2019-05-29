using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Bonuses
{
    public class HealthPack : IDrawableGameObject, ICollidable
    {
        private readonly Microsoft.Xna.Framework.Game _game;
        private readonly Random _random;
        private readonly ISprite _sprite;

        private float _xSpeed;
        private float _ySpeed;
        private Vector2 _position;

        public HealthPack(Microsoft.Xna.Framework.Game game, Random random, ISprite sprite)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
        }

        public bool IsEnabled { get; set; }

        public bool IsVisible
        {
            get => _sprite.IsVisible;
            set => _sprite.IsVisible = value;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Rectangle CollisionBounds => new Rectangle((int)Position.X, (int)Position.Y, _sprite.Bounds.Width, _sprite.Bounds.Height);

        public void Initialize()
        {
            _ySpeed = 2;

            Reset();
        }

        public void Update()
        {
            if (_position.Y >= _game.Window.ClientBounds.Height) //Check if the health pack is still visible
            {
                _position.Y = -15;
                IsEnabled = false;
            }

            _position.Y += _ySpeed;

            _sprite.Position = Position;
        }

        public void Draw(GameTime gameTime)
        {
            _sprite.Draw(gameTime);
        }

        //Check if the enemy intersects with the specified gameObject
        public bool CheckCollision(ICollidable col)
        {
            return CollisionBounds.Intersects(col.CollisionBounds);
        }

        //Handle collision behaviour
        public void OnCollision(ICollidable col)
        {
            if (col is IPlayerGameObject)
            {
                //ToDo should do some damage calculation to check if meteor should be "destroyed"
                Reset();
            }
        }

        private void Reset()
        {
            _position.X = _random.Next(_game.Window.ClientBounds.Width - _sprite.Bounds.Width);
            _position.Y = -15;
            IsEnabled = false;
        }
    }
}