using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameData;
using SSSRegen.Source.States;

namespace SSSRegen.Source.Menus
{
    public class MenuFactory : IMenuFactory
    {
        private readonly GameContext _gameContext;

        public MenuFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public IGameMenu CreateMainMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.SelectedFontName);

            var mainMenu = new TextMenu(_gameContext, new GameMenuInput(new KeyboardInputController(Keyboard.GetState())));

            mainMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnSelectOnePlayer, GameConstants.GameStates.MenuState.OnePlayerMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectTwoPlayer, GameConstants.GameStates.MenuState.TwoPlayerMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectHelp, GameConstants.GameStates.MenuState.HelpMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnSelectQuit, GameConstants.GameStates.MenuState.QuitMenuText, regularFont, selectedFont),
            });

            return mainMenu;
        }

        public IGameMenu CreatePlayStateMenu()
        {
            throw new NotImplementedException();
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