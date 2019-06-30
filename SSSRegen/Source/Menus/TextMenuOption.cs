using System;
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
            SelectedText = new UIText(selectedFont, text, Color.Red);
            CalculateSize();
        }

        public UIText RegularText { get; }
        public UIText SelectedText { get; }
        public Action OptionAction { get; }
        public Vector2 MaxSize { get; private set; }
        
        private void CalculateSize()
        {
            MaxSize = new Vector2(
                Math.Max(RegularText.Size.X, SelectedText.Size.X),
                Math.Max(SelectedText.Size.Y, SelectedText.Size.Y));
        }
    }
}