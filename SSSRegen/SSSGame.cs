﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Audio;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Audio;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.States;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace SSSRegen
{
    public class SSSGame : Game
    {
        private readonly IGameTime _gameTime;
        private readonly GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        private IGameAudioManager _gameAudioManager;
        private GameContext _gameContext;
        
        public SSSGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.IsFullScreen = true;

            Content.RootDirectory = "Content";

            IsFixedTimeStep = false;

            _gameTime = new Source.Core.GameStateMachine.GameTime();
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

            _gameAudioManager = new GameAudioManager();

            _gameAudioManager.Initialize();

            var screenSizeManager = new ScreenSizeManager(
                _graphics,
                new ScreenResolutionConverter(),
                GameConstants.GameSetupConstants.VirtualResolution);

            //ToDo Remove this line once player preference settings are implemented
            screenSizeManager.SetScreenResolution(ScreenResolutionOption.SRO_1920X1080);

            _gameContext = new GameContext(
                this,
                _spriteBatch,
                screenSizeManager,
                _gameAudioManager);

            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphicsComponent(_gameContext)), false);

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

            _gameTime.ElapsedGameTime = gameTime.ElapsedGameTime;
            _gameTime.TotalGameTime = gameTime.TotalGameTime;

            _gameContext.StateMachine.ActiveState.Update(_gameTime);

            _gameAudioManager.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameTime.ElapsedGameTime = gameTime.ElapsedGameTime;
            _gameTime.TotalGameTime = gameTime.TotalGameTime;

            _gameContext.StateMachine.ActiveState.Draw(_gameTime);
            
            base.Draw(gameTime);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Fonts
            _gameContext.AssetManager.LoadFont(GameConstants.GameStateConstants.MenuStateConstants.RegularFontName, GameConstants.GameStateConstants.MenuStateConstants.RegularFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName, GameConstants.GameStateConstants.MenuStateConstants.SelectedFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName, GameConstants.GameStateConstants.MenuStateConstants.LogoFontFileName);
            
            //Background Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStateConstants.SplashStateConstants.Textures.BackgroundTextureName, GameConstants.GameStateConstants.SplashStateConstants.Textures.BackgroundTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStateConstants.MenuStateConstants.Textures.BackgroundTextureName, GameConstants.GameStateConstants.MenuStateConstants.Textures.BackgroundTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStateConstants.PlayStateConstants.Textures.BackgroundTextureName, GameConstants.GameStateConstants.PlayStateConstants.Textures.BackgroundTextureFileName);

            //Bonus Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.BonusConstants.HealthPackConstants.Textures.RedTextureName, GameConstants.BonusConstants.HealthPackConstants.Textures.RedTextureFileName);

            //Projectile Textures
            //ToDo Add different player types
            //_gameContext.AssetManager.LoadTexture(GameConstants.Projectiles.Bullet1.Textures.BlueTextureName, GameConstants.Projectiles.Bullet1.Textures.BlueTextureFileName);
            //_gameContext.AssetManager.LoadTexture(GameConstants.Projectiles.Bullet2.Textures.GreenTextureName, GameConstants.Projectiles.Bullet2.Textures.GreenTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ProjectileConstants.Bullet3Constants.Textures.RedTextureName, GameConstants.ProjectileConstants.Bullet3Constants.Textures.RedTextureFileName);

            //Player Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.RedShipTextureName, GameConstants.PlayerConstants.PlayerShip1Constants.Textures.RedShipTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.RedLifeIconTextureName, GameConstants.PlayerConstants.PlayerShip1Constants.Textures.RedLifeIconTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.LightDamageTextureName, GameConstants.PlayerConstants.PlayerShip1Constants.Textures.LightDamageTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.MediumDamageTextureName, GameConstants.PlayerConstants.PlayerShip1Constants.Textures.MediumDamageTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.HeavyDamageTextureName, GameConstants.PlayerConstants.PlayerShip1Constants.Textures.HeavyDamageTextureFileName);


            //Thruster Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame1TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame1TextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame2TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame2TextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame3TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame3TextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame4TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame4TextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame5TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame5TextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame6TextureName, GameConstants.ThrusterConstants.Thruster1Constants.Textures.Frame6TextureFileName);

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
            _gameContext.AssetManager.LoadTexture(GameConstants.EnemyConstants.Enemy1Constants.Textures.BlackTextureName, GameConstants.EnemyConstants.Enemy1Constants.Textures.BlackTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.EnemyConstants.Enemy2Constants.Textures.BlueTextureName, GameConstants.EnemyConstants.Enemy2Constants.Textures.BlueTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.EnemyConstants.Enemy3Constants.Textures.GreenTextureName, GameConstants.EnemyConstants.Enemy3Constants.Textures.GreenTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.EnemyConstants.Enemy4Constants.Textures.RedTextureName, GameConstants.EnemyConstants.Enemy4Constants.Textures.RedTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.EnemyConstants.Enemy5Constants.Textures.BlackTextureName, GameConstants.EnemyConstants.Enemy5Constants.Textures.BlackTextureFileName);

            //Meteor Textures
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor2Constants.Textures.GreyTextureName, GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor2Constants.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor3Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor3Constants.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor4Constants.Textures.GreyTextureName, GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor4Constants.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor2Constants.Textures.GreyTextureName, GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor2Constants.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor3Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor3Constants.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Textures.GreyTextureName, GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor2Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor2Constants.Textures.BrownTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Textures.GreyTextureName, GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Textures.GreyTextureFileName);
            _gameContext.AssetManager.LoadTexture(GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor2Constants.Textures.BrownTextureName, GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor2Constants.Textures.BrownTextureFileName);

            //Menu SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.SplashStateConstants.Audio.SplashScreenSoundEffectName, GameConstants.GameStateConstants.SplashStateConstants.Audio.SplashScreenSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectName, GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuSelectionConfirmedSoundEffectName, GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuSelectionConfirmedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectName, GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectName, GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectName, GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectFileName);

            //Player SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.PlayerConstants.Audio.DestroyedSoundEffectName, GameConstants.PlayerConstants.Audio.DestroyedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.PlayerConstants.Audio.HitSoundEffectName, GameConstants.PlayerConstants.Audio.HitSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.PlayerConstants.Audio.InvulnerableSoundEffectName, GameConstants.PlayerConstants.Audio.InvulnerableSoundEffectFileName);

            //Bullet SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.ProjectileConstants.Bullet1Constants.Audio.ShootSoundEffectName, GameConstants.ProjectileConstants.Bullet1Constants.Audio.ShootSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.ProjectileConstants.Bullet2Constants.Audio.ShootSoundEffectName, GameConstants.ProjectileConstants.Bullet2Constants.Audio.ShootSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.ProjectileConstants.Bullet3Constants.Audio.ShootSoundEffectName, GameConstants.ProjectileConstants.Bullet3Constants.Audio.ShootSoundEffectFileName);

            //Thruster SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.ThrusterConstants.Thruster1Constants.Audio.ThrustingSoundEffectName, GameConstants.ThrusterConstants.Thruster1Constants.Audio.ThrustingSoundEffectFileName);

            //Bonus SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.BonusConstants.HealthPackConstants.Audio.CollectedSoundEffectName, GameConstants.BonusConstants.HealthPackConstants.Audio.CollectedSoundEffectFileName);

            //Meteor SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.MeteorConstants.Audio.HitSoundEffectName, GameConstants.MeteorConstants.Audio.HitSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.MeteorConstants.BigMeteorConstants.Audio.DestroyedSoundEffectName, GameConstants.MeteorConstants.BigMeteorConstants.Audio.DestroyedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.MeteorConstants.MediumMeteorConstants.Audio.DestroyedSoundEffectName, GameConstants.MeteorConstants.MediumMeteorConstants.Audio.DestroyedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.MeteorConstants.SmallMeteorConstants.Audio.DestroyedSoundEffectName, GameConstants.MeteorConstants.SmallMeteorConstants.Audio.DestroyedSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.MeteorConstants.TinyMeteorConstants.Audio.DestroyedSoundEffectName, GameConstants.MeteorConstants.TinyMeteorConstants.Audio.DestroyedSoundEffectFileName);

            //Main Menu Music
            _gameContext.AssetManager.LoadSong(GameConstants.GameStateConstants.MenuStateConstants.Audio.BackgroundMusicName, GameConstants.GameStateConstants.MenuStateConstants.Audio.BackgroundMusicFileName);

            //Play State Music
            _gameContext.AssetManager.LoadSong(GameConstants.GameStateConstants.PlayStateConstants.Audio.BackgroundMusicName, GameConstants.GameStateConstants.PlayStateConstants.Audio.BackgroundMusicFileName);
            _gameContext.AssetManager.LoadSong(GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverMusicName, GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverMusicFileName);

            //Play State SoundEffects
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GetReadySoundEffectName, GameConstants.GameStateConstants.PlayStateConstants.Audio.GetReadySoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.IncomingSoundEffectName, GameConstants.GameStateConstants.PlayStateConstants.Audio.IncomingSoundEffectFileName);
            _gameContext.AssetManager.LoadSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverSoundEffectName, GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverSoundEffectFileName);

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