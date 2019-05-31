using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SSSRegen.Source.Core
{
    public class TextMenuComponent : DrawableGameComponent
    {
        private readonly SpriteBatch spriteBatch = null; //SpriteBatch
        private readonly SpriteFont _regularFont, _selectedFont; //Fonts
        private Color _regularColour = Color.Red, _selectedColour = Color.White; //Colours
        private Vector2 __position = new Vector2(); //Menu _position
        private int _selectedIndex = 0; //Currently selected item
        private readonly List<string> _menuItems; //List of menu items
        private int _width, _height; //Size of menu in pixels
        //User input
        private KeyboardState _oldKeyboardState;
        private GamePadState _oldGamePadState;

        public void SetMenuItems(string[] items) //Set the menu options
        {
            _menuItems.Clear();
            _menuItems.AddRange(items);
            CalculateBounds();
        }

        ///Width of menu in pixels
        public int Width => _width;

        ///Height of menu in pixels
        public int Height => _height;

        ///Selected menu item index
        public int SelectedIndex 
        {
            get => _selectedIndex;
            set => _selectedIndex = value;
        }

        ///Regular item colour
        public Color RegularColour 
        {
            get => _regularColour;
            set => _regularColour = value;
        }
        ///Selected item colour
        public Color SelectedColour 
        {
            get => _selectedColour;
            set => _selectedColour = value;
        }

        ///_position of component on screen
        public Vector2 _position 
        {
            get => __position;
            set => __position = value;
        }

        private void CalculateBounds()
        {
            //Sets values to zero so that the values are reset each time this method is called
            _height = 0;
            _width = 0;
            foreach (string item in _menuItems) //Loop through items in the menu
            {
                Vector2 size = _selectedFont.MeasureString(item); //Calculates the width of the string
                if (size.X > _width)
                {
                    _width = (int)size.X;
                }
                _height += _selectedFont.LineSpacing + 5; //Calculates the height of the string and adds extra spacing
            }
        }

        public TextMenuComponent(Game game, SpriteFont normalFont, SpriteFont selectedFont) //"normalFont" for regular items, "selectedFont" for highlighted items
            : base(game)
        {
            // TODO: Construct any child components here
            _regularFont = normalFont;
            _selectedFont = selectedFont;
            _menuItems = new List<string>();

            //Get the current sprite batch
            spriteBatch = (SpriteBatch)
                Game.Services.GetService(typeof(SpriteBatch));

            //User input
            _oldKeyboardState = Keyboard.GetState();
            _oldGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();

            bool down, up;
            //Keyboard
            down = (_oldKeyboardState.IsKeyDown(Keys.Down) && (keyboardState.IsKeyUp(Keys.Down)));
            up = (_oldKeyboardState.IsKeyDown(Keys.Up) && (keyboardState.IsKeyUp(Keys.Up)));
            //GamePad
            down |= (_oldGamePadState.DPad.Down == ButtonState.Pressed) && (gamePadState.DPad.Down == ButtonState.Released);
            up |= (_oldGamePadState.DPad.Up == ButtonState.Pressed) && (gamePadState.DPad.Up == ButtonState.Released);

            if (down)
            {
                _selectedIndex++; //Increases the selected index by 1
                //If the bottom of the menu is passed, loop up to the start of the menu
                if (_selectedIndex == _menuItems.Count)
                {
                    _selectedIndex = 0;
                }
            }

            if (up)
            {
                _selectedIndex--; //Decreases the selected index by 1
                //If the top of the menu is passed, loop down to the bottom of the menu
                if (_selectedIndex < 0)
                {
                    _selectedIndex = _menuItems.Count - 1;
                }
            }
            _oldKeyboardState = keyboardState; //In the next frame current state of the keyboard and last state of the keyboard will be set
            _oldGamePadState = gamePadState; //In the next frame current state of the gamepad and last state of the gamepad will be set
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            float y = __position.Y;
            for (int i = 0; i < _menuItems.Count; i++) //Loop through the menu items
            {
                SpriteFont font; //Chosen font
                Color theColour; //Font colour
                //If the item is the selected item, draw it with the highlighted font
                if (i == SelectedIndex)
                {
                    font = _selectedFont;
                    theColour = _selectedColour;
                }
                //Else draw it with the normal font
                else
                {
                    font = _regularFont;
                    theColour = _regularColour;
                }

                //Draw a shadow for the text
                spriteBatch.DrawString(font, _menuItems[i], new Vector2(__position.X + 1, y + 1), Color.Black);
                //Draw the text item
                spriteBatch.DrawString(font, _menuItems[i], new Vector2(__position.X, y), theColour);
                y += font.LineSpacing;
            }

            base.Draw(gameTime);
        }
    }
}
