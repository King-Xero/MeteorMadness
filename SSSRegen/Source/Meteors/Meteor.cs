using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Meteors
{
    public class Meteor : IDrawableGameObject, IDamageable, ICollidable
    {
        private readonly Microsoft.Xna.Framework.Game _game;
        private readonly Random _random;
        private readonly ISprite _sprite;

        private float _xSpeed;
        private float _ySpeed;
        private Vector2 _position;

        public Meteor(Microsoft.Xna.Framework.Game game, Random random, ISprite sprite)
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
            Reset();
        }

        public void Update()
        {
            //If the enemy is off screen reset it
            if (Position.Y >= _game.Window.ClientBounds.Height ||
                Position.X >= _game.Window.ClientBounds.Width ||
                Position.X <= 0)
            {
                Reset();
            }
            //Move the enemy
            _position.X += _xSpeed;
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
            //Set the enemy to a random _position along the top of the screen, with random vertical and horizontal speed
            _position.X = _random.Next(_game.Window.ClientBounds.Width - _sprite.Bounds.Width);
            _position.Y = 0;
            _xSpeed = _random.Next(3) - 1;
            _ySpeed = 1 + _random.Next(4);
            //ToDo When object pooling is implemented disable objects when they are reset
            IsEnabled = true;
        }
    }
}