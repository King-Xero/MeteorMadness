using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.States
{
    public class SplashState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _splashStateGraphics;
        
        public SplashState(GameContext gameContext, IGraphicsComponent<IGameState> splashStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _splashStateGraphics = splashStateGraphics ?? throw new ArgumentNullException(nameof(splashStateGraphics));
        }

        public override void Initialize()
        {
            _splashStateGraphics.Initialize(this);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.ElapsedGameTime.Seconds > GameConstants.GameStates.SplashState.SplashStateDisplayTime)
            {
                var mainMenu = _gameContext.Factories.MenuFactory.CreateMainMenu();
                
                //Go to main menu scene
                _gameContext.StateMachine.AddState(new MainMenuState(_gameContext, new MainMenuStateGraphics(_gameContext), mainMenu), true);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _splashStateGraphics.Draw(this);

            base.Draw(gameTime);
        }
    }
}