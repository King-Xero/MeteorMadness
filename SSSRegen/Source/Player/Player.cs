using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SSSRegen.Source.Player
{
    /// <summary>
    /// This is a game component that implements the player
    /// </summary>
    public class Player : DrawableGameComponent
    {

        private Texture2D _texture; //Sprite texture
        private Rectangle _spriteRectangle; //Represents where the sprite picture is
        private Vector2 __position; //_position of player
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private PlayerIndex _playerIndex; //Player ID
        private Rectangle _screenBounds; //Screen Area
        private int _score; //Score points
        private int _health; //Health points
        private const int INITIAL_HEALTH = 100; //Amount of health the player starts with

        public Player(Game game, ref Texture2D spriteSheet, PlayerIndex playerId, Rectangle rectangle)
            : base(game)
        {
            // TODO: Construct any child components here
            _texture = spriteSheet;
            __position = new Vector2();
            _playerIndex = playerId;
            _spriteRectangle = rectangle;

#if XBOX360 //"Safe area" of TV on Xbox 360
            screenBounds = new Rectangle((int)(Game.Window.ClientBounds.Width * 0.03f),
            (int)(Game.Window.ClientBounds.Height * 0.03f),
            Game.Window.ClientBounds.Width - (int)(Game.Window.ClientBounds.Width * 0.03f),
            Game.Window.ClientBounds.Height - (int)(Game.Window.ClientBounds.Width * 0.03f));
#else //PC "Safe area"
            _screenBounds = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
#endif
        }

        public void Reset() //Put the player in start _position on screen
        {
            if (_playerIndex == PlayerIndex.One)
            {
                __position.X = _screenBounds.Width / 3; //Player ones's _position along the bottom of the screen
            }
            else
            {
                __position.X = (int)(_screenBounds.Width / 1.5); //Player two's _position along the bottom of the screen
            }

            __position.Y = _screenBounds.Height - _spriteRectangle.Height - 10; //Places the player(s) at the very bottom of the screen
            _score = 0; //Resets the score to zero
            _health = INITIAL_HEALTH; //Resets the health to intial value
        }

        public int Score //Total points for the player
        {
            get => _score;
            //Doesn't allow a negative score
            set => _score = value < 0 ? 0 : value;
        }

        public int Health //Health Remaining
        {
            get => _health;
            set => _health = value;
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
        public override void Update(GameTime gameTime) //Update the player _position, health, and score
        {
            // TODO: Add your update code here
            //Move the player with an Xbox controller
            GamePadState gamePadStatus = GamePad.GetState(_playerIndex);
            __position.X += (int)((gamePadStatus.ThumbSticks.Left.X * 3) * 4);
            //Move the player with the keyboard
            if (_playerIndex == PlayerIndex.One)
            {
                HandlePlayer1Keyboard();
            }
            else
            {
                HandlePlayer2Keyboard();
            }

            KeepInBounds(); //Keep the player on screen

            //Update the score
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromMilliseconds(1))
            {
                _score++; //Increases score
            }

            base.Update(gameTime);
        }

        private void KeepInBounds()
        {
            if (__position.X < _screenBounds.Left)
            {
                __position.X = _screenBounds.Left;
            }
            if (__position.X > _screenBounds.Width - _spriteRectangle.Width)
            {
                __position.X = _screenBounds.Width - _spriteRectangle.Width;
            }
        }

        private void HandlePlayer1Keyboard() //Keyboard input for player one
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.A)) //Move the player left
            {
                __position.X -= 6;
            }
            if (keyboard.IsKeyDown(Keys.D)) //Move the player right
            {
                __position.X += 6;
            }
        }

        private void HandlePlayer2Keyboard() //Keyboard input for player one
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left)) //Move the player left
            {
                __position.X -= 6;
            }
            if (keyboard.IsKeyDown(Keys.Right)) //Move the player right
            {
                __position.X += 6;
            }
        }

        public override void Draw(GameTime gameTime) //Draw the player sprite
        {

            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch)); //Get the current sprite batch

            sBatch.Draw(_texture, __position, _spriteRectangle, Color.White); //Draw the sprite

            base.Draw(gameTime);
        }

        public Rectangle GetBounds() //Rectangle used to check for collisions
        {
            return new Rectangle((int)__position.X, (int)__position.Y, _spriteRectangle.Width, _spriteRectangle.Height);
        }
    }
}