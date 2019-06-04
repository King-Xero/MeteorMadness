using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Core
{
    public class TextMenu : ITextMenu
    {
        private readonly GameContext _gameContext;
        private readonly IInputComponent<ITextMenu> _menuInputComponent;
        private readonly string _regularFontName;
        private readonly string _selectedFontName;
        private SpriteFont _regularTextFont;
        private Color _regularTextColor;
        private SpriteFont _selectedTextFont;
        private Color _selectedTextColor;

        private Dictionary<string, Action> _menuItems;
        private int _width;
        private int _height;
        
        //ToDo Refactor to make text menu reusable. Pass parameters to creation specific text menu.
        public TextMenu(GameContext gameContext, IInputComponent<ITextMenu> menuInputComponent, string regularFontName, string selectedFontName)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _menuInputComponent = menuInputComponent ?? throw new ArgumentNullException(nameof(menuInputComponent));
            _regularFontName = regularFontName;
            _selectedFontName = selectedFontName;
        }

        public bool IsVisible { get; set; }
        public bool Enabled { get; set; }
        public Vector2 Position { get; set; }
        public int Width => _width;
        public int Height => _height;
        public int SelectedIndex { get; set; }

        public void SetMenuItems(Dictionary<string, Action> items)
        {
            _menuItems.Clear();
            foreach (var item in items)
            {
                _menuItems.Add(item.Key, item.Value);
            }
            CalculateBounds();
        }

        public void Initialize()
        {
            SelectedIndex = 0;
            _menuItems = new Dictionary<string, Action>();
            _regularTextFont = _gameContext.AssetManager.GetFont(_regularFontName);
            _selectedTextFont = _gameContext.AssetManager.GetFont(_selectedFontName);

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
            float y = Position.Y;
            for (int i = 0; i < _menuItems.Count; i++) //Loop through the menu items
            {
                SpriteFont drawFont;
                Color drawColour;
                if (i == SelectedIndex)
                {
                    drawFont = _selectedTextFont;
                    drawColour = _selectedTextColor;
                }
                else
                {
                    drawFont = _regularTextFont;
                    drawColour = _regularTextColor;
                }

                //Draw a shadow for the text
                _gameContext.GameGraphics.DrawString(new UIText(drawFont, _menuItems.Keys.ElementAtOrDefault(i)), new Vector2(Position.X + 1, y + 1), Color.Black);
                //Draw the text item
                _gameContext.GameGraphics.DrawString(new UIText(drawFont, _menuItems.Keys.ElementAtOrDefault(i)), new Vector2(Position.X, y), drawColour);
                y += drawFont.LineSpacing;
            }
        }

        public void SelectCurrentItem()
        {
            var selectedAction = _menuItems?.Values.ElementAtOrDefault(SelectedIndex);
            selectedAction?.Invoke();
        }

        private void CalculateBounds()
        {
            //Sets values to zero so that the values are reset each time this method is called
            _height = 0;
            _width = 0;
            foreach (string item in _menuItems.Keys)
            {
                Vector2 size = _selectedTextFont.MeasureString(item);
                //Calculates the width of the menu
                if (size.X > _width)
                {
                    _width = (int)size.X;
                }
                //Calculates the height of the menu and adds extra spacing
                _height += _selectedTextFont.LineSpacing + 5; 
            }
        }
    }
}