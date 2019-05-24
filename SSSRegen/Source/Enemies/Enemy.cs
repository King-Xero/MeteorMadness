using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;

namespace SSSRegen.Source.Enemies
{
    public class Enemy : Sprite
    {
        //Random number generator
        private readonly Random _random;
        
        public Enemy(Game game, ref Texture2D spriteSheet, List<Rectangle> spriteFrames, float xSpeed, float ySpeed) : base(game, ref spriteSheet)
        {
            Frames = spriteFrames;

            //Initialize the random number generator
            _random = new Random(GetHashCode());

            //Set the enemy to a random _position along the top of the screen, with random vertical and horizontal speed
            _position.X = _random.Next(Game.Window.ClientBounds.Width - _currentFrame.Width);
            _position.Y = 0;
            YSpeed = 1 + _random.Next(4);
            XSpeed = _random.Next(3) - 1;
        }

        //Vertical velocity
        public int YSpeed { get; set; }

        //Horizontal velocity
        public int XSpeed { get; set; }

        //Unique identifier for this enemy
        public int Index { get; set; }

        //Check if the enemy intersects with the specified rectangle, returns true if a collision occurs
        public bool CheckCollision(Rectangle rect)
        {
            Rectangle spriteRect = new Rectangle((int)_position.X, (int)_position.Y, _currentFrame.Width, _currentFrame.Height);
            return spriteRect.Intersects(rect);
        }
    }
}