using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.ToDelete;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Player;

namespace SSSRegen.Source.Screens
{
    /// <summary>
    /// This is a game component that implements the play screen
    /// </summary>
    public class PlayScreen : GameScreen
    {
        //Basics
        private readonly Texture2D playTexture; //Texture for all the elements of the game
        private readonly SpriteBatch spriteBatch = null;

        //Game elements
        private OldPlayer _player1; //Player 1
        private OldPlayer _player2; //Player 2
        private MeteorManager _meteors; //Meteor Manager
        private EnemyManager _enemies; //Enemy Manager
        private OldHealthPack _oldHealthPack; //Health pack
        private RumblePad _rumblePad; //Rumble for Xbox controller
        private PlayerScore _scorePlayer1; //Score for player 1
        private PlayerScore _scorePlayer2; //Score for player 2

        //GUI
        private Vector2 _pause_position; //_position of pause prompt
        private Vector2 _gameover_position; //_position of game over prompt
        private Rectangle _pauseRect = new Rectangle(170, 225, 144, 41); //Rectangle for pause prompt
        private Rectangle _gameoverRect = new Rectangle(173, 272, 266, 41); //Rectangle for game over prompt

        //GameState elements
        private bool _paused; //Is the game paused?
        private bool _isGameOver; //Is it Game over?
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private bool _isTwoPlayer; //Are there 2 players?


        public PlayScreen(Game game, Texture2D spriteSheet, Texture2D backgroundTexture, SpriteFont font)
            : base(game)
        {
            // TODO: Construct any child components here

            //Add the game background image
            var background = new ImageComponent(game, backgroundTexture, ImageComponent.DrawMode.Stretch);
            Components.Add(background);

            playTexture = spriteSheet;

            //Add the meteors
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            _meteors = new MeteorManager(Game, ref playTexture);
            Components.Add(_meteors);

            //Add the enemies
            _enemies = new EnemyManager(Game, ref playTexture);
            Components.Add(_enemies);

            //Add player 1
            _player1 = new OldPlayer(Game, ref playTexture, PlayerIndex.One, new Rectangle(105, 0, 50, 40));
            _player1.Initialize();
            Components.Add(_player1);

            //Add player 2
            _player2 = new OldPlayer(Game, ref playTexture, PlayerIndex.Two, new Rectangle(105, 100, 50, 50));
            _player2.Initialize();
            Components.Add(_player2);

            //Add the score for player 1
            _scorePlayer1 = new PlayerScore(game, font, Color.Blue);
            _scorePlayer1._position = new Vector2(10, 10);
            Components.Add(_scorePlayer1);
            //Add the score for player 2
            _scorePlayer2 = new PlayerScore(game, font, Color.Green);
            _scorePlayer2._position = new Vector2(Game.Window.ClientBounds.Width - 200, 10);
            Components.Add(_scorePlayer2);

            //Add the rumble for Xbox controller
            _rumblePad = new RumblePad(game);
            Components.Add(_rumblePad);

            //Add the health packs
            _oldHealthPack = new OldHealthPack(game, ref playTexture);
            _oldHealthPack.Initialize();
            Components.Add(_oldHealthPack);
        }

        public bool IsTwoPlayer //Indicate whether or not 2 player mode
        {
            get => _isTwoPlayer;
            set => _isTwoPlayer = value;
        }

        //True, if the game is in game over state
        public bool IsGameOver => _isGameOver;

        public bool IsPaused //Paused mode
        {
            get => _paused;
            set => _paused = value;
        }

        public override void Show() //Show the play screen
        {
            _meteors.Initialize();
            _enemies.Initialize();
            _oldHealthPack.PutInStart_position();
            _player1.Reset();
            _player2.Reset();

            _paused = false; //Game is NOT paused when started
            //Paused prompt _position
            _pause_position.X = (Game.Window.ClientBounds.Width - _pauseRect.Width) / 2;
            _pause_position.Y = (Game.Window.ClientBounds.Height - _pauseRect.Height) / 2;

            _isGameOver = false; //Game over is NOT true when game is started
            //Game over prompt _position
            _gameover_position.X = (Game.Window.ClientBounds.Width - _gameoverRect.Width) / 2;
            _gameover_position.Y = (Game.Window.ClientBounds.Height - _gameoverRect.Height) / 2;

            //Player 2 elements are visible and enabled depending on the status of "twoPlayers"
            _player2.Visible = _isTwoPlayer;
            _player2.Enabled = _isTwoPlayer;
            _scorePlayer2.Visible = _isTwoPlayer;
            _scorePlayer2.Enabled = _isTwoPlayer;

            base.Show();
        }

        public override void Hide() //Hide the play screen
        {
            //Stop the controller rumble
            _rumblePad.Stop(PlayerIndex.One);
            _rumblePad.Stop(PlayerIndex.Two);

            base.Hide();
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
            if ((!_paused) && (!_isGameOver))
            {
                HandleDamages(); //Check meteor collisions
                HandleHealthPack(gameTime); //Check if player has collected health pack
                //Update player's score and health
                _scorePlayer1.ScorePoints = _player1.Score;
                _scorePlayer1.HealthPoints = _player1.Health;
                //if its a two player game, update player 2's score and health
                if (_isTwoPlayer)
                {
                    _scorePlayer2.ScorePoints = _player2.Score;
                    _scorePlayer2.HealthPoints = _player2.Health;
                }
                //Check if the player is dead
                _isGameOver = ((_player1.Health <= 0) || (_player2.Health <= 0));
                if (_isGameOver)
                {
                    _player1.Visible = (_player1.Health > 0);
                    _player2.Visible = (_player2.Health > 0) && _isTwoPlayer;
                    //Stop the rumble
                    _rumblePad.Stop(PlayerIndex.One);
                    _rumblePad.Stop(PlayerIndex.Two);
                }
                base.Update(gameTime);
            }
            if (_isGameOver) //Meteors, enemies and health packs keep their animation when its game over
            {
                _meteors.Update(gameTime);
                _enemies.Update(gameTime);
                _oldHealthPack.Update(gameTime);
            }
        }

        private void HandleDamages() //Check collisions
        {
            //Check small meteor collisions for player 1
            if (_meteors.SmallMeteorCollision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 5; //Player damage
            }

            //Check medium meteor collisions for player 1
            if (_meteors.MediumMeteorCollision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 10; //Player damage
            }

            //Check small meteor collisions for player 2
            if (_isTwoPlayer)
            {
                if (_meteors.SmallMeteorCollision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 5; //Player damage
                }
            }

            //Check medium meteor collisions for player 2
            if (_isTwoPlayer)
            {
                if (_meteors.MediumMeteorCollision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 10; //Player damage
                }
            }

            //Check enemy1 collisions for player 1
            if (_enemies.Enemy1Collision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 20; //Player damage
            }

            //Check enemy2 collisions for player 1
            if (_enemies.Enemy2Collision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 30; //Player damage
            }

            //Check enemy3 collisions for player 1
            if (_enemies.Enemy3Collision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 40; //Player damage
            }

            //Check boss collisions for player 1
            if (_enemies.BossCollision(_player1.GetBounds()))
            {
                _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                _player1.Health -= 50; //Player damage
            }

            //Check enemy1 collisions for player 2
            if (_isTwoPlayer)
            {
                if (_enemies.Enemy1Collision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 20; //Player damage
                }
            }

            //Check enemy2 collisions for player 2
            if (_isTwoPlayer)
            {
                if (_enemies.Enemy2Collision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 30; //Player damage
                }
            }

            //Check enemy3 collisions for player 2
            if (_isTwoPlayer)
            {
                if (_enemies.Enemy3Collision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 40; //Player damage
                }
            }

            //Check enemy collisions for player 2
            if (_isTwoPlayer)
            {
                if (_enemies.BossCollision(_player2.GetBounds()))
                {
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 50; //Player damage
                }
            }

            //Check if the players collide with each other
            if (_isTwoPlayer)
            {
                if (_player1.GetBounds().Intersects(_player2.GetBounds()))
                {
                    //Player 1
                    _rumblePad.GamePadRumble(PlayerIndex.One, 500, 1.0f, 1.0f); //Activate rumble
                    _player1.Health -= 10; //Player damage
                    _player1.Score -= 10; //Score penalty
                    //Player 2
                    _rumblePad.GamePadRumble(PlayerIndex.Two, 500, 1.0f, 1.0f); //Activate rumble
                    _player2.Health -= 10; //Player damage
                    _player2.Score -= 10; //Score penalty
                }
            }
        }

        private void HandleHealthPack(GameTime gameTime)
        {
            //Check if player 1 collects a health pack
            if (_oldHealthPack.CheckCollision(_player1.GetBounds()))
            {
                _elapsedTime = TimeSpan.Zero;
                _oldHealthPack.PutInStart_position(); //Reset health pack
                _player1.Health += 50; //Health boost
            }

            //Check if player 2 collects a health pack
            if (_isTwoPlayer)
            {
                if (_oldHealthPack.CheckCollision(_player2.GetBounds()))
                {
                    _elapsedTime = TimeSpan.Zero;
                    _oldHealthPack.PutInStart_position(); //Reset health pack
                    _player2.Health += 50; //Health boost
                }
            }

            //Check if its time to send a health pack
            _elapsedTime += gameTime.ElapsedGameTime;
            if (_elapsedTime > TimeSpan.FromSeconds(20))
            {
                _elapsedTime -= TimeSpan.FromSeconds(20);
                _oldHealthPack.Enabled = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime); //Draw all Game Components

            if (_paused)
            {
                spriteBatch.Draw(playTexture, _pause_position, _pauseRect, Color.White); //Draw the paused prompt
            }

            if (_isGameOver)
            {
                spriteBatch.Draw(playTexture, _gameover_position, _gameoverRect, Color.White); //Draw the paused prompt
            }
        }
    }
}