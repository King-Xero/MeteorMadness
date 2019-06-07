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
                new TextMenuOption(_gameContext, OnMainMenuSelectOnePlayer, GameConstants.GameStates.MenuState.OnePlayerMenuText, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnMainMenuSelectTwoPlayer, GameConstants.GameStates.MenuState.TwoPlayerMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnMainMenuSelectHelp, GameConstants.GameStates.MenuState.HelpMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnMainMenuSelectQuit, GameConstants.GameStates.MenuState.QuitMenuText, regularFont, selectedFont),
            });

            return mainMenu;
        }

        public IGameMenu CreatePlayStateMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.SelectedFontName);

            var mainMenu = new TextMenu(_gameContext, new GameMenuInput(new KeyboardInputController(Keyboard.GetState())));

            mainMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnPlayStateSelectResume, GameConstants.GameStates.PlayState.MenuTextResume, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectHelp, GameConstants.GameStates.PlayState.MenuTextHelp, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectQuit, GameConstants.GameStates.PlayState.MenuTextQuit, regularFont, selectedFont),
            });

            return mainMenu;
        }

        private void OnMainMenuSelectOnePlayer()
        {
            //ToDo Change to play state with one active player
            _gameContext.StateMachine.AddState(new PlayState(_gameContext, new PlayStateGraphics(_gameContext)), true);
        }

        private void OnMainMenuSelectTwoPlayer()
        {
            //ToDo Change to play state with two active players
            _gameContext.StateMachine.AddState(new PlayState(_gameContext, new PlayStateGraphics(_gameContext)), true);
        }

        private void OnMainMenuSelectHelp()
        {
            //ToDo Change to help state
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), false);
        }

        private void OnMainMenuSelectQuit()
        {
            //ToDo Close game
            throw new NotImplementedException();
        }

        private void OnPlayStateSelectResume()
        {
            throw new NotImplementedException();
        }

        private void OnPlayStateSelectHelp()
        {
            //ToDo Show help state
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), false);
        }

        private void OnPlayStateSelectQuit()
        {
            var mainMenu = _gameContext.Factories.MenuFactory.CreateMainMenu();
            //Go to main menu scene
            _gameContext.StateMachine.AddState(new MainMenuState(_gameContext, new MainMenuStateGraphics(_gameContext), mainMenu), true);
        }
    }
}