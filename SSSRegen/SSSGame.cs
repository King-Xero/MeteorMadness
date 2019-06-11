using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.States;

namespace SSSRegen
{
    public class SSSGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameContext _gameContext;

        public SSSGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), _spriteBatch);
            _gameContext = new GameContext(this, _spriteBatch);

            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), false);

            //_gameContext.StateMachine.ActiveState.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _gameContext.StateMachine.ProcessStateChanges();

            _gameContext.StateMachine.ActiveState.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _gameContext.StateMachine.ActiveState.Draw(gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.RegularFontName, GameConstants.GameStates.MenuState.RegularFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.SelectedFontName, GameConstants.GameStates.MenuState.SelectedFontFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName, GameConstants.GameStates.PlayState.PlayElementsSpriteSheetFilePath);

            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}