using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Menus
{
    public class TextMenu : IGameMenu
    {
        private readonly GameContext _gameContext;
        private readonly IInputComponent<IGameMenu> _menuInputComponent;

        private List<IMenuOption> _menuItems;
        private int _width;
        private int _height;
        private Vector2 _position;

        //ToDo Refactor to make text menu reusable. Pass parameters to creation specific text menu.
        public TextMenu(GameContext gameContext, IInputComponent<IGameMenu> menuInputComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _menuInputComponent = menuInputComponent ?? throw new ArgumentNullException(nameof(menuInputComponent));
        }

        public int SelectedIndex { get; set; }

        public void SetMenuItems(List<IMenuOption> items)
        {
            _menuItems = new List<IMenuOption>();
            foreach (var item in items)
            {
                _menuItems.Add(item);
            }
            SelectedIndex = 0;
            CalculateBounds();
        }

        public void SelectCurrentItem()
        {
            _menuItems?.ElementAtOrDefault(SelectedIndex)?.OptionAction();
        }

        public void Initialize()
        {
            _menuInputComponent.Initialize(this);
        }

        public void Update(GameTime gameTime)
        {
            _menuInputComponent.Update(this);
            if (SelectedIndex == _menuItems.Count)
            {
                SelectedIndex = 0;
            }
            if (SelectedIndex < 0)
            {
                SelectedIndex = _menuItems.Count - 1;
            }
        }

        public void Draw(GameTime gameTime)
        {
            float y = _position.Y;

            //ToDo probably shouldn't be newing up objects in draw methods.
            for (int i = 0; i < _menuItems.Count; i++)
            {
                if (_menuItems.ElementAtOrDefault(i) is TextMenuOption textOption)
                {
                    IUIText uiText = i == SelectedIndex ? textOption.SelectedText : textOption.RegularText;
                    //Draw a shadow for the text
                    _gameContext.GameGraphics.DrawString(uiText, new Vector2(_position.X + 1, y + 1), Color.Black);
                    //Draw the text item
                    _gameContext.GameGraphics.DrawString(uiText, new Vector2(_position.X, y), uiText.TextColor);

                    y += uiText.Height;  //uiText.Font.LineSpacing;
                }
                else if (_menuItems.ElementAtOrDefault(i) is SpriteMenuOption spriteOption)
                {
                    ISprite sprite = i == SelectedIndex ? spriteOption.SelectedSprite : spriteOption.RegularSprite;
                    //Draw a shadow for the text
                    _gameContext.GameGraphics.Draw(sprite, new Rectangle((int) _position.X + 1, (int) y + 1, sprite.Width, sprite.Height), Color.Black);
                    //Draw the text item
                    _gameContext.GameGraphics.Draw(sprite, new Rectangle((int)_position.X + 1, (int)y + 1, sprite.Width, sprite.Height), Color.White);

                    y += sprite.Height;
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
                _width = Math.Max(_width, item.MaxWidth);
                //Calculates the height of the menu and adds extra spacing
                _height += item.MaxHeight + GameConstants.GameStates.MenuState.ItemSpacing; 
            }

            _position = new Vector2((_gameContext.ScreenBounds.Width / 2) - (_width / 2));
        }
    }
}