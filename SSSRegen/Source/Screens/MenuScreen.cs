using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;

namespace SSSRegen.Source.Screens
{
    /// <summary>
    /// This is a game component that implements the menu screen
    /// </summary>
    public class MenuScreen : GameScreen
    {
        private readonly TextMenuComponent menu; //Text items for the menu screen
        private readonly Texture2D _elements;

        private SpriteBatch _spriteBatch = null;

        private Rectangle _line1Rectangle = new Rectangle(0, 0, 536, 131); //The rectangle that contains the image for Line 1 in the texture

        private Vector2 _line1_position; //Holds the _position of line 1 on the screen

        private Rectangle _line2Rectangle = new Rectangle(120, 165, 517, 130); //The rectangle that contains the image for Line 2 in the texture

        private Vector2 _line2_position; //Holds the _position of line 2 on the screen

        private Rectangle _line3Rectangle = new Rectangle(8, 304, 375, 144); //The rectangle that contains the image for Line 3 in the texture

        private Vector2 _line3_position; //Holds the _position of line 3 on the screen
        private bool _showLine3; //Shows or hides line 3
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public MenuScreen(Game game, SpriteFont smallFont, SpriteFont largeFont, Texture2D background, Texture2D elements) : base(game)
        {
            // TODO: Construct any child components here

            this._elements = elements;
            Components.Add(new ImageComponent(game, background, ImageComponent.DrawMode.Stretch)); //Add image component

            //Create Menu
            string[] items =
                {"One Player", "Two Players", "Help", "Quit"}; //Creates and array with entries for the menu
            menu = new TextMenuComponent(game, smallFont, largeFont);
            menu.SetMenuItems(items);
            Components.Add(menu);

            //Get the current sprite batch
            _spriteBatch = (SpriteBatch) Game.Services.GetService(typeof(SpriteBatch));
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

            if (!menu.Visible) //If the menu isn't visible
            {
                if (_line2_position.X >= (Game.Window.ClientBounds.Width - 595) / 2)
                {
                    _line2_position.X -= 15; //Moves line 2 left if it is not in its final _position
                }

                if (_line1_position.X <= (Game.Window.ClientBounds.Width - 715) / 2)
                {
                    _line1_position.X += 15; //Moves line 1 right if it is not in its final _position
                }
                else
                {
                    menu.Visible = true; //Makes the menu visible
                    menu.Enabled = true; //Enables the Menu

#if XBOX360 //Calculation for _position of line 3 on Xbox 360
                    line3_position =
 new Vector2((line2_position.X + line2Rectangle.Width - line3Rectangle.Width / 2), line2_position.Y);
#else //Calculation for _position of line 3 on PC
                    _line3_position =
                        new Vector2((_line2_position.X + _line2Rectangle.Width - _line3Rectangle.Width / 2) - 80,
                            _line2_position.Y);
#endif
                    _showLine3 = true; //Shows line 3
                }
            }
            else //If line 1 and line 2 are in their final _position, makes line 3 "flash" 
            {
                _elapsedTime += gameTime.ElapsedGameTime; //Increases "elapsedTime" using elapsed game time
                if (_elapsedTime > TimeSpan.FromSeconds(1)) // "Flash threshold"
                {
                    _elapsedTime -= TimeSpan.FromSeconds(1); //Decreases "elapsedTime" below "flash threshold"
                    _showLine3 = !_showLine3; //"Flashes" line 3 off and on
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Draw(_elements, _line1_position, _line1Rectangle, Color.White); //Draws line 1
            _spriteBatch.Draw(_elements, _line2_position, _line2Rectangle, Color.White); //Draws line 2
            if (_showLine3) //If line 3 is showing, draw line 3
            {
                _spriteBatch.Draw(_elements, _line3_position, _line3Rectangle, Color.White);
            }
        }

        public override void Show() //Show the menu screen
        {
            _line1_position.X = -1 * _line1Rectangle.Width;
            _line1_position.Y = 40;
            _line2_position.X = Game.Window.ClientBounds.Width;
            _line2_position.Y = 180;
            menu._position = new Vector2((Game.Window.ClientBounds.Width - menu.Width) / 2, 330); //Center menu on screen
            //These are visible when the game title is done
            menu.Visible = false;
            menu.Enabled = false;
            _showLine3 = false;

            base.Show();
        }

        public override void Hide() //Hide the menu screen
        {
            base.Hide();
        }

        //Used to select an option from the menu screen
        public int SelectedMenuIndex => menu.SelectedIndex;
    }
}