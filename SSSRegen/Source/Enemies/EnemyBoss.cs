﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;

namespace SSSRegen.Source.Enemies
{
    /// <summary>
    /// This is a game component that implements the boss enemy
    /// </summary>
    public class EnemyBoss : OldSprite
    {

        private int _ySpeed; //Vertical velocity
        private int _xSpeed; //Horizontal velocity
        private Random _random; //Random number generator
        private int _index; //Unique ID for this enemy


        public EnemyBoss(Game game, ref Texture2D spriteSheet)
            : base(game, ref spriteSheet)
        {
            // TODO: Construct any child components here
            Frames = new List<Rectangle>();
            Rectangle frame = new Rectangle();
            frame.X = 65; //X coordinate of first frame
            frame.Y = 397; //Y coordinate of first frame
            frame.Width = 96; //frame width
            frame.Height = 96; //frame height
            Frames.Add(frame); //Add frame to list of frames

            _random = new Random(GetHashCode()); //Initialize the random number generator
            PutinStart_position(); //Put enemy in start _position
        }

        public void PutinStart_position()
        {
            //Set the boss to a random _position along the top of the screen, with random vertical and horizontal speed
            _position.X = _random.Next(Game.Window.ClientBounds.Width - _currentFrame.Width);
            _position.Y = 0;
            YSpeed = 1 + _random.Next(4);
            XSpeed = _random.Next(3) - 1;
        }


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //Check if boss is still visible
            if ((_position.Y >= Game.Window.ClientBounds.Height) ||
                (_position.X >= Game.Window.ClientBounds.Width) ||
                (_position.X <= 0))
            {
                PutinStart_position();
            }
            //Move the boss
            _position.Y += _ySpeed;
            _position.X += _xSpeed;

            base.Update(gameTime);
        }

        //Vertical velocity
        public int YSpeed
        {
            get => _ySpeed;
            //_frameDelay = 200 - (Yspeed * 5);
            set => _ySpeed = value;
        }

        //Horizontal velocity
        public int XSpeed
        {
            get => _xSpeed;
            set => _xSpeed = value;
        }

        //Meteor identifier
        public int Index
        {
            get => _index;
            set => _index = value;
        }

        //Check if the boss intersects with the specified rectangle, returns true if a collision occurs
        public bool CheckCollision(Rectangle rect)
        {
            Rectangle spriteRect = new Rectangle((int)_position.X, (int)_position.Y, _currentFrame.Width, _currentFrame.Height);
            return spriteRect.Intersects(rect);
        }
    }
}