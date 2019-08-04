using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Core.Graphics
{
    public class AnimatedSprite : IAnimatedSprite
    {
        private readonly IEnumerable<ISprite> _spritesFrames;
        private readonly float _frameDelay;

        private ISprite _currentSprite;
        private int _frameIterator;
        private TimeSpan _elapsedTime;

        public AnimatedSprite(IEnumerable<ISprite> spritesFrames, float frameDelay)
        {
            _spritesFrames = spritesFrames ?? throw new ArgumentNullException(nameof(spritesFrames));
            _frameDelay = frameDelay;

            _currentSprite = spritesFrames.FirstOrDefault();
            if (_currentSprite == null) throw new ArgumentException("Collection contains no sprite frames", nameof(spritesFrames));

            _frameIterator = 0;
            _elapsedTime = TimeSpan.Zero;
        }

        public Texture2D Texture => _currentSprite.Texture;
        public Rectangle? SourceRectangle => _currentSprite.SourceRectangle;
        public Vector2 Size => _currentSprite.Size;
        public Vector2 Origin => _currentSprite.Origin;
        public bool IsVisible { get; set; }

        public void Update(IGameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime <= TimeSpan.FromMilliseconds(_frameDelay)) return;

            _elapsedTime -= TimeSpan.FromMilliseconds(_frameDelay);

            _frameIterator++;

            if (_frameIterator == _spritesFrames.Count())
            {
                _frameIterator = 0;
            }

            _currentSprite = _spritesFrames.ElementAt(_frameIterator);
        }
    }
}