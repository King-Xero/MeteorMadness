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
        }

        public UIText(SpriteFont font, string text, Color color)
        {
            Font = font ?? throw new ArgumentNullException(nameof(font));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            TextColor = color;
        }

        public SpriteFont Font { get; }
        public Color TextColor { get; set ; }
        public string Text { get; }
        public int Width => (int) Font.MeasureString(Text).X;
        public int Height => (int) Font.MeasureString(Text).Y;
    }
}