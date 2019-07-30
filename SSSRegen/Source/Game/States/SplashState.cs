using System;
using SSSRegen.Source.Core.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.States
{
    public class SplashState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IDrawableComponent<IGameState> _splashStateGraphics;
        
        public SplashState(GameContext gameContext, IDrawableComponent<IGameState> splashStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _splashStateGraphics = splashStateGraphics ?? throw new ArgumentNullException(nameof(splashStateGraphics));
        }

        public override void Initialize()
        {
            _splashStateGraphics.Initialize(this);
            base.Initialize();

            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.SplashStateConstants.Audio.SplashScreenSoundEffectName));
        }

        public override void Update(IGameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > GameConstants.GameStateConstants.SplashStateConstants.SplashStateDisplayTime)
            {
                var mainMenu = _gameContext.MenuFactory.CreateMainMenu();
                
                //Go to main menu scene
                _gameContext.StateMachine.AddState(new MainMenuState(_gameContext, new MainMenuStateGraphics(_gameContext), mainMenu), true);
            }

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _splashStateGraphics.Draw(this, gameTime);

            base.Draw(gameTime);
        }
    }
}