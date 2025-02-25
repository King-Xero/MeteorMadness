﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Core.Interfaces.Menus;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Core.Menu
{
    public class TextMenu : IGameMenu
    {
        private readonly GameContext _gameContext;
        private readonly IComponent<IGameMenu> _menuInputComponent;
        private readonly SoundEffect _menuNavigateSoundEffect;

        private List<IMenuOption> _menuItems;
        private List<Vector2> _menuItemPositions;
        private int _width;
        private int _height;
        private Vector2 _position;
        private int _selectedIndex;
        //Used to stop the menu navigate sound playing when the menu is created, or menu items are set
        private bool _canPlaySoundEffect;
        private bool _isEnabled = true;

        //ToDo Refactor to make text menu reusable. Pass parameters to creation specific text menu.
        public TextMenu(GameContext gameContext, IComponent<IGameMenu> menuInputComponent, SoundEffect menuNavigateSoundEffect)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _menuInputComponent = menuInputComponent ?? throw new ArgumentNullException(nameof(menuInputComponent));
            _menuNavigateSoundEffect = menuNavigateSoundEffect ?? throw new ArgumentException(nameof(menuInputComponent));
        }

        //ToDo reset selected index when menu is enabled
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                //Reset the menu index when the menu is opened/closed
                SelectedIndex = 0;

                _isEnabled = value;
            }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_canPlaySoundEffect)
                {
                    _gameContext.GameAudio.PlaySoundEffect(_menuNavigateSoundEffect);
                }
                _selectedIndex = value;
            }
        }

        public void SetMenuItems(List<IMenuOption> items)
        {
            _canPlaySoundEffect = false;
            _menuItems = new List<IMenuOption>();
            foreach (var item in items)
            {
                _menuItems.Add(item);
            }
            SelectedIndex = 0;
            CalculateBounds();
            CalculateItemPositions();
            _canPlaySoundEffect = true;
        }

        public void SelectCurrentItem()
        {
            _menuItems?.ElementAtOrDefault(SelectedIndex)?.OptionAction();
        }

        public void Initialize()
        {
            _menuInputComponent.Initialize(this);
        }

        public void Update(IGameTime gameTime)
        {
            _menuInputComponent.Update(this, gameTime);
            //ToDo check if selected index is changed when menu is not enabled

            if (SelectedIndex == _menuItems.Count)
            {
                SelectedIndex = 0;
            }

            if (SelectedIndex < 0)
            {
                SelectedIndex = _menuItems.Count - 1;
            }
        }

        public void Draw(IGameTime gameTime)
        {
            if (IsEnabled)
            {
                for (int i = 0; i < _menuItems.Count; i++)
                {
                    if (_menuItems.ElementAtOrDefault(i) is TextMenuOption textOption)
                    {
                        IUIText uiText = i == SelectedIndex ? textOption.SelectedText : textOption.RegularText;
                        //Draw a shadow for the text
                        _gameContext.GameGraphics.DrawText(uiText, _menuItemPositions[i] + Vector2.One, Color.Black);
                        //Draw the text item
                        _gameContext.GameGraphics.DrawText(uiText, _menuItemPositions[i], uiText.TextColor);
                    }
                    else if (_menuItems.ElementAtOrDefault(i) is SpriteMenuOption spriteOption)
                    {
                        ISprite sprite = i == SelectedIndex ? spriteOption.SelectedSprite : spriteOption.RegularSprite;

                        //Draw a shadow for the sprite
                        _gameContext.GameGraphics.Draw(sprite, _menuItemPositions[i] + Vector2.One, Color.Black, 0, sprite.Origin);
                        //Draw the sprite item
                        _gameContext.GameGraphics.Draw(sprite, _menuItemPositions[i], Color.White, 0, sprite.Origin);
                    }
                }
            }
        }
        
        private void CalculateBounds()
        {
            //Sets values to zero so that the values are reset each time this method is called
            _height = 0;
            _width = 0;
            foreach (var item in _menuItems)
            {
                _width = Math.Max(_width, item.MaxSize.X).ToInt();
                //Calculates the height of the menu and adds extra spacing
                _height += item.MaxSize.Y.ToInt() + GameConstants.GameStateConstants.MenuStateConstants.ItemSpacing; 
            }

            //ToDo put menu in correct position
            _position = new Vector2(_gameContext.GameGraphics.ScreenBounds.Width / 2 - _width / 2);
        }

        private void CalculateItemPositions()
        {
            _menuItemPositions = new List<Vector2>();
            var y = _position.Y;

            foreach (var item in _menuItems)
            {
                _menuItemPositions.Add(new Vector2(_position.X, y));

                y += item.MaxSize.Y;
            }
        }
    }
}