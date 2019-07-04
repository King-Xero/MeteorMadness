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
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1366,
                PreferredBackBufferHeight = 768
            };

            Content.RootDirectory = "Content";

            IsFixedTimeStep = false;
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
            //Fonts
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.RegularFontName, GameConstants.GameStates.MenuState.RegularFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.SelectedFontName, GameConstants.GameStates.MenuState.SelectedFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.LogoFontName, GameConstants.GameStates.MenuState.LogoFontFileName);
            
            //Background Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.SplashState.Textures.BackgroundTextureName, GameConstants.GameStates.SplashState.Textures.BackgroundTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.MenuState.Textures.BackgroundTextureName, GameConstants.GameStates.MenuState.Textures.BackgroundTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.PlayState.Textures.BackgroundTextureName, GameConstants.GameStates.PlayState.Textures.BackgroundTextureFileName);

            //Bonus Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.Bonuses.HealthPack.Textures.RedTextureName, GameConstants.Bonuses.HealthPack.Textures.RedTextureFileName);

            //Projectile Textures
            //ToDo Add different player types
            //_gameContext.AssetManager.LoadTexture(GameConstants.Projectiles.Bullet1.Textures.BlueTextureName, GameConstants.Projectiles.Bullet1.Textures.BlueTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Projectiles.Bullet2.Textures.GreenTextureName, GameConstants.Projectiles.Bullet2.Textures.GreenTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Projectiles.Bullet3.Textures.RedTextureName, GameConstants.Projectiles.Bullet3.Textures.RedTextureFileName);

            //Player Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip1.Textures.RedShipTextureName, GameConstants.Player.PlayerShip1.Textures.RedShipTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip1.Textures.RedLifeIconTextureName, GameConstants.Player.PlayerShip1.Textures.RedLifeIconTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip1.Textures.LightDamageTextureName, GameConstants.Player.PlayerShip1.Textures.LightDamageTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip1.Textures.MediumDamageTextureName, GameConstants.Player.PlayerShip1.Textures.MediumDamageTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip1.Textures.HeavyDamageTextureName, GameConstants.Player.PlayerShip1.Textures.HeavyDamageTextureFileName);


            //ToDo Add different player types
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip2.Textures.GreenTextureName, GameConstants.Player.PlayerShip2.Textures.GreenTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip2.Textures.LightDamageTextureName, GameConstants.Player.PlayerShip2.Textures.LightDamageTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip2.Textures.MediumDamageTextureName, GameConstants.Player.PlayerShip2.Textures.MediumDamageTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip2.Textures.HeavyDamageTextureName, GameConstants.Player.PlayerShip2.Textures.HeavyDamageTextureFileName);

            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip3.Textures.BlueTextureName, GameConstants.Player.PlayerShip3.Textures.BlueTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip3.Textures.LightDamageTextureName, GameConstants.Player.PlayerShip3.Textures.LightDamageTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip3.Textures.MediumDamageTextureName, GameConstants.Player.PlayerShip3.Textures.MediumDamageTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Player.PlayerShip3.Textures.HeavyDamageTextureName, GameConstants.Player.PlayerShip3.Textures.HeavyDamageTextureFileName);

            //Enemy Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.Enemies.Enemy1.Textures.BlackTextureName, GameConstants.Enemies.Enemy1.Textures.BlackTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Enemies.Enemy2.Textures.BlueTextureName, GameConstants.Enemies.Enemy2.Textures.BlueTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Enemies.Enemy3.Textures.GreenTextureName, GameConstants.Enemies.Enemy3.Textures.GreenTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Enemies.Enemy4.Textures.RedTextureName, GameConstants.Enemies.Enemy4.Textures.RedTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Enemies.Enemy5.Textures.BlackTextureName, GameConstants.Enemies.Enemy5.Textures.BlackTextureFileName);

            //Meteor Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.BigMeteor1.Textures.BrownTextureName, GameConstants.Meteors.BigMeteor1.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.BigMeteor2.Textures.GreyTextureName, GameConstants.Meteors.BigMeteor2.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.BigMeteor3.Textures.BrownTextureName, GameConstants.Meteors.BigMeteor3.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.BigMeteor4.Textures.GreyTextureName, GameConstants.Meteors.BigMeteor4.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.MediumMeteor1.Textures.BrownTextureName, GameConstants.Meteors.MediumMeteor1.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.MediumMeteor2.Textures.GreyTextureName, GameConstants.Meteors.MediumMeteor2.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.MediumMeteor3.Textures.BrownTextureName, GameConstants.Meteors.MediumMeteor3.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.SmallMeteor1.Textures.GreyTextureName, GameConstants.Meteors.SmallMeteor1.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.SmallMeteor2.Textures.BrownTextureName, GameConstants.Meteors.SmallMeteor2.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.TinyMeteor1.Textures.GreyTextureName, GameConstants.Meteors.TinyMeteor1.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.Meteors.TinyMeteor2.Textures.BrownTextureName, GameConstants.Meteors.TinyMeteor2.Textures.BrownTextureFileName);

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