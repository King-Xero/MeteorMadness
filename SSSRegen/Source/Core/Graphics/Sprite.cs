using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Core.Graphics
{
    public class Sprite : ISprite
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            SourceRectangle = null;
            Size = new Vector2(Texture.Width, Texture.Height);
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            IsVisible = true;
        }

        public Sprite(Texture2D texture, Rectangle sourceRectangle)
        {
            Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            SourceRectangle = sourceRectangle;
            Size = new Vector2(SourceRectangle.Value.Width, SourceRectangle.Value.Height);
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            IsVisible = true;
        }

        public Texture2D Texture { get; }

        public Rectangle? SourceRectangle { get; }
        public Vector2 Size { get; }
        public Vector2 Origin { get; }
        public bool IsVisible { get; set; }
    }
}