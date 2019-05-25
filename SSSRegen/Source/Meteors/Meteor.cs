using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Meteors
{
    public class Meteor : Sprite, IDamageableGameObject
    {
        //Random number generator
        private readonly Random _random;

        private float _xSpeed;
        private float _ySpeed;

        public Meteor(Game game, Random random, ref Texture2D spriteSheet, List<Rectangle> spriteFrames) : base(game, ref spriteSheet)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
            Frames = spriteFrames ?? throw new ArgumentNullException(nameof(spriteFrames));
        }

        public Rectangle CollisionBounds => new Rectangle((int)_position.X, (int)_position.Y, _currentFrame.Width, _currentFrame.Height);

        public override void Initialize()
        {
            Reset();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //If the meteor is off screen reset it
            if ((_position.Y >= Game.Window.ClientBounds.Height) ||
                (_position.X >= Game.Window.ClientBounds.Width) ||
                (_position.X <= 0))
            {
                Reset();
            }
            //Move the meteor
            _position.X += _xSpeed;
            _position.Y += _ySpeed;
            base.Update(gameTime);
        }

        //Check if the enemy intersects with the specified gameObject
        public bool CheckCollision(ICollisionGameObject gameObject)
        {
            return CollisionBounds.Intersects(gameObject.CollisionBounds);
        }

        //Handle collision behaviour
        public void OnCollision(ICollisionGameObject col)
        {
            if (col is IPlayerGameObject)
            {
                //ToDo should do some damage calculation to check if meteor should be "destroyed"
                Reset();
            }
        }

        private void Reset()
        {
            //Set the meteor to a random position along the top of the screen, with random vertical and horizontal speed
            _position.X = _random.Next(Game.Window.ClientBounds.Width - _currentFrame.Width);
            _position.Y = 0;
            _xSpeed = _random.Next(3) - 1;
            _ySpeed = 1 + _random.Next(4);
            //ToDo When object pooling is implemented disable objects when they are reset
            Enabled = true;
        }
    }
}