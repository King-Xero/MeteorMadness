using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core;
using SSSRegen.Source.Screens;
using Game = Microsoft.Xna.Framework.Game;

namespace SSSRegen
{
    /// <summary>
    /// This is the main type for your game
    /// 
    /// Code references:
    /// http://xnagpa.net/xnatutorials.php
    /// http://msdn.microsoft.com/en-us/library/bb195024.aspx 
    /// Learning XNA 3.0 by Aaron Reed
    /// Beginning XNA 3.0 Game Programming: From Novice to Professional by Alexandre Santos Lobão, Bruno Evangelista, José Antonio Leal de Farias, and Riemer Grootjans
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Game Screens
        private HelpScreen _helpScreen;
        private MenuScreen _menuScreen;
        private PlayScreen _playScreen;

        //Active game screen
        private GameScreen _activeScreen;

        //Textures
        private Texture2D _helpBackgroundTexture, _helpForegroundTexture;
        private Texture2D _menuBackgroundTexture, _menuElementsTexture;
        private Texture2D _playBackgroundTexture, _playElementsTexture;

        //Fonts
        private SpriteFont _smallFont, _largeFont, _scoreFont;

        //User input
        private KeyboardState _oldKeyboardState;
        private GamePadState _oldGamePadState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //this.graphics.IsFullScreen = true; //FullScreen
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), _spriteBatch);

            //Help Screen
            _helpBackgroundTexture = Content.Load<Texture2D>(@"HelpImages/HelpBackground"); //Help Screen Background
            _helpForegroundTexture = Content.Load<Texture2D>(@"HelpImages/HelpInfo"); //Help Screen Image
            _helpScreen = new HelpScreen(this, _helpBackgroundTexture, _helpForegroundTexture); //Creates the help screen
            Components.Add(_helpScreen); //Adds the help screen to the list of game components

            //Menu Screen
            _smallFont = Content.Load<SpriteFont>(@"MenuFonts/smallFont"); //Font for menu items
            _largeFont = Content.Load<SpriteFont>(@"MenuFonts/largeFont"); //Font for selected menu item
            _menuBackgroundTexture = Content.Load<Texture2D>(@"MenuImages/MenuBackground"); //Menu Screen Background
            _menuElementsTexture = Content.Load<Texture2D>(@"MenuImages/MenuElements"); //Menu Screen Title
            _menuScreen = new MenuScreen(this, _smallFont, _largeFont, _menuBackgroundTexture, _menuElementsTexture); //Creates the menu screen
            Components.Add(_menuScreen); //Adds the menu screen to the list of game components

            //Play Screen
            _scoreFont = Content.Load<SpriteFont>(@"PlayFonts/scoreFont"); //Font for the player's score and health
            _playElementsTexture = Content.Load<Texture2D>(@"PlayImages/SpriteSheet"); //Sprite Sheet for the game
            _playBackgroundTexture = Content.Load<Texture2D>(@"PlayImages/GameBackGround"); //Play Screen Background
            _playScreen = new PlayScreen(this, _playElementsTexture, _playBackgroundTexture, _scoreFont); //Creates the play screen
            Components.Add(_playScreen); //Adds the play screen to the list of game components

            //Screen to show on start
            _menuScreen.Show();
            _activeScreen = _menuScreen;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            HandleInput(); //Handle user input
            base.Update(gameTime);
        }

        private void HandleInput() //Handle user input
        {
            if (_activeScreen == _menuScreen) //Handle menu input
            {
                HandleMenuInput();
            }
            else if (_activeScreen == _helpScreen) //Handle help screen input
            {
                if (CheckEnterStart())
                {
                    ShowScreen(_menuScreen);
                }
            }
            else if (_activeScreen == _playScreen)
            {
                HandlePlayInput();
            }
        }

        private bool CheckEnterStart() //Check if the enter key or the start button was pressed, and if so, return true
        {
            //Get the game pad and keyboard state
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();

            bool result = (_oldKeyboardState.IsKeyDown(Keys.Enter) && (keyboardState.IsKeyUp(Keys.Enter)));
            result |= (_oldGamePadState.Buttons.Start == ButtonState.Pressed) && (gamePadState.Buttons.Start == ButtonState.Released);

            _oldKeyboardState = keyboardState;
            _oldGamePadState = gamePadState;

            return result;
        }

        private void HandleMenuInput() //Handle buttons and keyboard in the menu screen
        {
            if (CheckEnterStart())
            {
                switch (_menuScreen.SelectedMenuIndex)
                {
                    case 0: //Single player game
                        _playScreen.IsTwoPlayer = false;
                        ShowScreen(_playScreen);
                        break;
                    case 1: //Two player game
                        _playScreen.IsTwoPlayer = true;
                        ShowScreen(_playScreen);
                        break;
                    case 2: //Help screen
                        ShowScreen(_helpScreen);
                        break;
                    case 3: //Exit game
                        Exit();
                        break;
                }
            }
        }

        private void HandlePlayInput()
        {
            //Get the game pad and keyboard state
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();

            bool backKey = (_oldKeyboardState.IsKeyDown(Keys.Escape) && (keyboardState.IsKeyUp(Keys.Escape)));
            backKey |= (_oldGamePadState.Buttons.Back == ButtonState.Pressed) && (gamePadState.Buttons.Back == ButtonState.Released);

            bool enterKey = (_oldKeyboardState.IsKeyDown(Keys.Enter) && (keyboardState.IsKeyUp(Keys.Enter)));
            enterKey |= (_oldGamePadState.Buttons.Start == ButtonState.Pressed) && (gamePadState.Buttons.Back == ButtonState.Released);

            _oldKeyboardState = keyboardState; //Get the keyboard state
            _oldGamePadState = gamePadState; //Get the game pad state

            if (enterKey)
            {
                if (_playScreen.IsGameOver) //If its game over, the game exits to the menu screen
                {
                    ShowScreen(_menuScreen);
                }
                else //If the game is paused, the game starts again
                {
                    _playScreen.IsPaused = !_playScreen.IsPaused;
                }
            }
            if (backKey) //The game exits to the menu screen
            {
                ShowScreen(_menuScreen);
            }
        }

        protected void ShowScreen(GameScreen screen)
        {
            _activeScreen.Hide();
            _activeScreen = screen;
            screen.Show();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();//BlendState.AlphaBlend);
            // TODO: Add your drawing code here
            base.Draw(gameTime); //Draws all the child components
            _spriteBatch.End();
        }
    }
}
