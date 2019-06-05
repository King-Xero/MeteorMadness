using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.States
{
    public class MainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _mainMenuStateGraphics;
        private readonly IGameMenu _textMenu;
        
        public MainMenuState(GameContext gameContext, IGraphicsComponent<IGameState> mainMenuStateGraphics, IGameMenu textMenu)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _mainMenuStateGraphics = mainMenuStateGraphics ?? throw new ArgumentNullException(nameof(mainMenuStateGraphics));
            _textMenu = textMenu ?? throw new ArgumentNullException(nameof(textMenu));
        }

        public override void Initialize()
        {
            _mainMenuStateGraphics.Initialize(this);

            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.RegularFontName, GameConstants.GameStates.MenuState.RegularFontFileName);
            _gameContext.AssetManager.LoadFont(GameConstants.GameStates.MenuState.SelectedFontName, GameConstants.GameStates.MenuState.SelectedFontFileName);

            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.SelectedFontName);

            _textMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnSelectOnePlayer, GameConstants.GameStates.MenuState.OnePlayerMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectTwoPlayer, GameConstants.GameStates.MenuState.TwoPlayerMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectHelp, GameConstants.GameStates.MenuState.HelpMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectQuit, GameConstants.GameStates.MenuState.QuitMenuText, regularFont, selectedFont),
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