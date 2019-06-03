using System;
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
        }

        public SpriteFont Font { get; }
        public string Text { get; }
    }
}