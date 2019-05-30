using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class Sprite : ISprite
    {
        public Sprite(ref Texture2D texture)
        {
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            SourceRectangle = null;
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public Sprite(ref Texture2D texture, Rectangle? sourceRectangle)
        {
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            SourceRectangle = sourceRectangle ?? throw new ArgumentNullException(nameof(sourceRectangle));
            Width = SourceRectangle.Value.Width;
            Height = SourceRectangle.Value.Height;
        }

        public Texture2D Texture { get; }

        public Rectangle? SourceRectangle { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        //ToDo Animated Sprite
        //private List<Rectangle> _spriteFrames;
        //private long _frameDelay;
        //private int _frameIterator;
        //private TimeSpan _elapsedTime;

        //public Sprite(ref Texture2D texture, List<Rectangle> spriteFrames, long frameDelay)
        //{
        //    _texture = texture ?? throw new ArgumentNullException(nameof(texture));
        //    _spriteFrames = spriteFrames ?? throw new ArgumentNullException(nameof(spriteFrames));
        //    if (!_spriteFrames.Any()) throw new ArgumentException($"{nameof(spriteFrames)} does not contain any frames");

        //    _frameDelay = frameDelay;

        //    _sourceRectangle = _spriteFrames.FirstOrDefault();
        //    _frameIterator = 0;
        //    _elapsedTime = TimeSpan.Zero;
        //}

        //public Sprite(ref Texture2D texture, List<Rectangle> spriteFrames, Rectangle initialFrame, long frameDelay)
        //{
        //    _texture = texture ?? throw new ArgumentNullException(nameof(texture));
        //    _spriteFrames = spriteFrames ?? throw new ArgumentNullException(nameof(spriteFrames));
        //    if (!_spriteFrames.Any()) throw new ArgumentException($"{nameof(spriteFrames)} does not contain any frames");
        //    if (!_spriteFrames.Contains(initialFrame)) throw new ArgumentOutOfRangeException($"{nameof(initialFrame)} not found in list of frames");

        //    _frameDelay = frameDelay;

        //    _sourceRectangle = initialFrame;
        //    _frameIterator = _spriteFrames.IndexOf(initialFrame);
        //    _elapsedTime = TimeSpan.Zero;
        //}

        //public void Update(GameTime gameTime)
        //{
        //    _elapsedTime += gameTime.ElapsedGameTime;

        //    if (_elapsedTime <= TimeSpan.FromMilliseconds(_frameDelay)) return;

        //    _elapsedTime -= TimeSpan.FromMilliseconds(_frameDelay);
        //    _frameIterator++;
        //    if (_frameIterator == _spriteFrames.Count)
        //    {
        //        _frameIterator = 0;
        //    }

        //    _sourceRectangle = _spriteFrames[_frameIterator];
        //}
    }
}