using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Utils.Extensions;

namespace SSSRegen.Source.Menus
{
    public class TextMenu : IGameMenu
    {
        private readonly GameContext _gameContext;
        private readonly IComponent<IGameMenu> _menuInputComponent;

        private List<IMenuOption> _menuItems;
        private List<Vector2> _menuItemPositions;
        private int _width;
        private int _height;
        private Vector2 _position;

        private Rectangle _spriteOptionDrawRectangle;

        //ToDo Refactor to make text menu reusable. Pass parameters to creation specific text menu.
        public TextMenu(GameContext gameContext, IComponent<IGameMenu> menuInputComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _menuInputComponent = menuInputComponent ?? throw new ArgumentNullException(nameof(menuInputComponent));
        }

        public bool IsEnabled { get; set; } = true;
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
            CalculateItemPositions();
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
                float y = _position.Y;

                for (int i = 0; i < _menuItems.Count; i++)
                {
                    if (_menuItems.ElementAtOrDefault(i) is TextMenuOption textOption)
                    {
                        IUIText uiText = i == SelectedIndex ? textOption.SelectedText : textOption.RegularText;
                        //Draw a shadow for the text
                        _gameContext.GameGraphics.DrawText(uiText, _menuItemPositions[i] + Vector2.One, Color.Black);
                        //Draw the text item
                        _gameContext.GameGraphics.DrawText(uiText, _menuItemPositions[i], uiText.TextColor);

                        y += uiText.Size.Y; //uiText.Font.LineSpacing;
                    }
                    else if (_menuItems.ElementAtOrDefault(i) is SpriteMenuOption spriteOption)
                    {
                        ISprite sprite = i == SelectedIndex ? spriteOption.SelectedSprite : spriteOption.RegularSprite;

                        //Draw a shadow for the text
                        _gameContext.GameGraphics.Draw(
                            sprite,
                            ConfigureDrawRectangle((_menuItemPositions[i] + Vector2.One).X, (_menuItemPositions[i] + Vector2.One).Y, sprite.Size),
                            Color.Black);
                        //Draw the text item
                        _gameContext.GameGraphics.Draw(
                            sprite,
                            ConfigureDrawRectangle(_menuItemPositions[i].X, _menuItemPositions[i].Y, sprite.Size),
                            Color.White);
                        
                        y += sprite.Size.Y;
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
                _height += item.MaxSize.Y.ToInt() + GameConstants.GameStates.MenuState.ItemSpacing; 
            }

            //ToDo put menu in correct position
            _position = new Vector2(_gameContext.ScreenBounds.Width / 2 - _width / 2);
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

        private Rectangle ConfigureDrawRectangle(float xPosition, float yPosition, Vector2 size)
        {
            _spriteOptionDrawRectangle.X = xPosition.ToInt();
            _spriteOptionDrawRectangle.Y = yPosition.ToInt();
            _spriteOptionDrawRectangle.Width = size.X.ToInt();
            _spriteOptionDrawRectangle.Height = size.Y.ToInt();

            return _spriteOptionDrawRectangle;
        }
    }
}