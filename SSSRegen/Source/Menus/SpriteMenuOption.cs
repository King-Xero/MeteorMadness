﻿using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils.Extensions;

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
            MaxWidth = MathHelper.Max(RegularSprite.Size.X, SelectedSprite.Size.X).ToInt();
            MaxHeight = MathHelper.Max(RegularSprite.Size.Y, SelectedSprite.Size.Y).ToInt();
        }
    }
}