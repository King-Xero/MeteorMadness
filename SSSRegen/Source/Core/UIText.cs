using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class UIText : IUIText
    {
        public UIText(SpriteFont font, string text)
        {
            Font = font ?? throw new ArgumentNullException(nameof(font));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            TextColor = Color.White;
            Size = new Vector2(Font.MeasureString(Text).X, Font.MeasureString(Text).Y);
        }

        public UIText(SpriteFont font, string text, Color color)
        {
            Font = font ?? throw new ArgumentNullException(nameof(font));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            TextColor = color;
            Size = new Vector2(Font.MeasureString(Text).X, Font.MeasureString(Text).Y);
        }

        public SpriteFont Font { get; }
        public Color TextColor { get; set ; }
        public string Text { get; }
        public Vector2 Size { get; }
        public bool IsVisible { get; set; }
    }
}