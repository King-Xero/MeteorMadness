using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class SplashState : GameState
    {
        private readonly GameContext _gameContext;
        private Sprite _backgroundImage;

        public SplashState(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public override void Initialize()
        {
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.SplashState.BackgroundTextureName, GameConstants.GameStates.SplashState.BackgroundTextureFileName);
            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.SplashState.BackgroundTextureName));

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.ElapsedGameTime.Seconds > GameConstants.GameStates.SplashState.SplashStateDisplayTime)
            {
                //Go to main menu scene
                _gameContext.StateMachine.AddState(new MenuState(_gameContext), true);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.ScreenBounds, Color.White);

            base.Draw(gameTime);
        }
    }
}