using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class Sprite : ISprite
    {
        private readonly ISpriteBatch _spriteBatch;
        private readonly Texture2D _texture;
        private readonly List<Rectangle> _spriteFrames;
        private readonly long _frameDelay;

        private int _frameIterator;
        private TimeSpan _elapsedTime;
        private Rectangle _currentFrame;

        public Sprite(ISpriteBatch spriteBatch, ref Texture2D texture, List<Rectangle> spriteFrames, long frameDelay)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _texture = texture ?? throw new ArgumentNullException(nameof(texture));
            _spriteFrames = spriteFrames ?? throw new ArgumentNullException(nameof(spriteFrames));
            _frameDelay = frameDelay;

            _frameIterator = 0;
            _elapsedTime = TimeSpan.Zero;
            Position = Vector2.Zero;
            SpriteColor = Color.White;
        }

        public bool IsVisible { get; set; }

        public Vector2 Position { get; set; }

        public Color SpriteColor { get; set; }
        public Rectangle Bounds => _currentFrame;

        public void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime <= TimeSpan.FromMilliseconds(_frameDelay)) return;

            _elapsedTime -= TimeSpan.FromMilliseconds(_frameDelay);
            _frameIterator++;
            if (_frameIterator == _spriteFrames.Count)
            {
                _frameIterator = 0;
            }

            _currentFrame = _spriteFrames[_frameIterator];
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, Position, _currentFrame, SpriteColor);
        }


    }
}