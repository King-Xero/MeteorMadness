using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class MainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _mainMenuStateGraphics;
        private readonly ITextMenu _textMenu;
        
        public MainMenuState(GameContext gameContext, IGraphicsComponent<IGameState> mainMenuStateGraphics, ITextMenu textMenu)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _mainMenuStateGraphics = mainMenuStateGraphics ?? throw new ArgumentNullException(nameof(mainMenuStateGraphics));
            _textMenu = textMenu ?? throw new ArgumentNullException(nameof(textMenu));
        }

        public override void Initialize()
        {
            _mainMenuStateGraphics.Initialize(this);

            _textMenu.SetMenuItems(new Dictionary<string, Action>
            {
                {GameConstants.GameStates.MenuState.OnePlayerMenuText, OnSelectOnePlayer},
                {GameConstants.GameStates.MenuState.TwoPlayerMenuText, OnSelectTwoPlayer},
                {GameConstants.GameStates.MenuState.HelpMenuText, OnSelectHelp},
                {GameConstants.GameStates.MenuState.QuitMenuText, OnSelectQuit},
            });


            _textMenu.Initialize();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _mainMenuStateGraphics.Update(this);

            _textMenu.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainMenuStateGraphics.Draw(this);

            _textMenu.Draw(gameTime);

            base.Draw(gameTime);
        }

        private void OnSelectOnePlayer()
        {
            //ToDo Change to play state with one active player
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), true);
        }

        private void OnSelectTwoPlayer()
        {
            //ToDo Change to play state with two active players
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), true);
        }

        private void OnSelectHelp()
        {
            //ToDo Change to help state
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), false);
        }

        private void OnSelectQuit()
        {
            //ToDo Close game
            throw new NotImplementedException();
        }
    }
}