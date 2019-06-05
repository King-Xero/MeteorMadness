using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
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
            RegularText = new UIText(regularFont, text);
            SelectedText = new UIText(selectedFont, text);
            CalculateSize();
        }

        public UIText RegularText { get; }
        public UIText SelectedText { get; }
        public Action OptionAction { get; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }
        
        private void CalculateSize()
        {
            MaxWidth = Math.Max(RegularText.Width, SelectedText.Width);
            MaxHeight = Math.Max(SelectedText.Height, SelectedText.Height);
        }
    }
}