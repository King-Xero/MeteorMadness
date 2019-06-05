using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Menus
{
    public class TextMenuOption : ITextMenuOption
    {
        private readonly GameContext _gameContext;

        public TextMenuOption(GameContext gameContext, Action optionAction, string text, SpriteFont regularFont, SpriteFont selectedFont)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            OptionAction = optionAction;
            Text = text;
            RegularFont = regularFont;
            SelectedFont = selectedFont;
            CalculateSize();
        }

        public string Text { get; }
        public SpriteFont RegularFont { get; }
        public SpriteFont SelectedFont { get; }
        public Action OptionAction { get; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }
        
        private void CalculateSize()
        {
            Vector2 regularSize = RegularFont.MeasureString(Text);
            Vector2 selectedSize = SelectedFont.MeasureString(Text);
            MaxWidth = (int) Math.Max(regularSize.X, selectedSize.X);
            MaxHeight = (int) Math.Max(regularSize.Y, selectedSize.Y);
        }
    }
}