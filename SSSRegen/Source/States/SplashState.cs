using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
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
        }

        public override void Update(IGameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > GameConstants.GameStates.SplashState.SplashStateDisplayTime)
            {
                var mainMenu = _gameContext.Factories.MenuFactory.CreateMainMenu();
                
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