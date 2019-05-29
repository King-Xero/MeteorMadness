using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Core
{
    public class OldSprite : DrawableGameComponent
    {
        private int _activeFrame; //Active frame from the sprite sheet animation
        private readonly Texture2D _texture; //Will hold the sprite sheet texture
        private List<Rectangle> _frames; //List of sprite frames from the texture

        protected Vector2 _position;
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        protected Rectangle _currentFrame; //Rectangle of the current sprite frame
        protected long _frameDelay;
        private SpriteBatch _spBatch;

        public OldSprite(Game game, ref Texture2D spriteSheet) : base(game)
        {
            // ToDo: Construct any child components here

            _texture = spriteSheet;
            _activeFrame = 0;
        }

        ///List with frames of the animated sprite
        public List<Rectangle> Frames 
        {
            get => _frames;
            set => _frames = value;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            _spBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            _elapsedTime += gameTime.ElapsedGameTime;
            //Check if next frame should be displayed, and if so, change it each n milliseconds
            if (_elapsedTime > TimeSpan.FromMilliseconds(_frameDelay))
            {
                _elapsedTime -= TimeSpan.FromMilliseconds(_frameDelay);
                _activeFrame++;
                if (_activeFrame == _frames.Count)
                {
                    _activeFrame = 0;
                }
                _currentFrame = _frames[_activeFrame]; //Get the current frame
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spBatch.Draw(_texture, _position, _currentFrame, Color.White); //Draw the current frame in the current _position on the screen

            base.Draw(gameTime);
        }
    }
}