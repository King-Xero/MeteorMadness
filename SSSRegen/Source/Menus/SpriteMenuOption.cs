using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Menus
{
    public class SpriteMenuOption : ISpriteMenuOption
    {
        private readonly GameContext _gameContext;

        public SpriteMenuOption(GameContext gameContext, Action optionAction, ISprite regularSprite, ISprite selectedSprite)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            OptionAction = optionAction;
            RegularSprite = regularSprite;
            SelectedSprite = selectedSprite;
            CalculateSize();
        }

        public ISprite RegularSprite { get; }
        public ISprite SelectedSprite { get; }
        public Action OptionAction { get; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }

        private void CalculateSize()
        {
            MaxWidth = Math.Max(RegularSprite.Width, SelectedSprite.Width);
            MaxHeight = Math.Max(RegularSprite.Width, SelectedSprite.Width);
        }
    }
}