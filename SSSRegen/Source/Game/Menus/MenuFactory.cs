using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Input;
using SSSRegen.Source.Core.Interfaces.Menus;
using SSSRegen.Source.Core.Menu;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Input;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.States;

namespace SSSRegen.Source.Game.Menus
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
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName);

            var mainMenu = new TextMenu(_gameContext, new GameMenuInputComponent(new KeyboardInputController()),
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectName));

            mainMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnMainMenuSelectOnePlayer, GameConstants.GameStateConstants.MenuStateConstants.PlayMenuText, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnMainMenuSelectTwoPlayer, GameConstants.GameStates.MenuState.TwoPlayerMenuText, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnMainMenuSelectHelp, GameConstants.GameStates.MenuState.HelpMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnMainMenuSelectQuit, GameConstants.GameStateConstants.MenuStateConstants.QuitMenuText, regularFont, selectedFont),
            });

            return mainMenu;
        }

        public IGameMenu CreatePlayStatePauseMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName);

            var playPauseMenu = new TextMenu(_gameContext, new PlayStatePauseMenuInputComponent(new KeyboardInputController()),
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectName));

            playPauseMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, () => OnPlayStateSelectResume(playPauseMenu), GameConstants.GameStateConstants.PlayStateConstants.MenuTextResume, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnPlayStateSelectHelp, GameConstants.GameStates.PlayState.MenuTextHelp, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectQuit, GameConstants.GameStateConstants.PlayStateConstants.MenuTextQuit, regularFont, selectedFont),
            });

            return playPauseMenu;
        }

        public IGameMenu CreatePlayStateGameOverMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName);

            var playGameOverMenu = new TextMenu(_gameContext, new GameMenuInputComponent(new KeyboardInputController()), 
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectName));

            playGameOverMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnMainMenuSelectOnePlayer, GameConstants.GameStateConstants.PlayStateConstants.MenuTextPlayAgain, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectQuit, GameConstants.GameStateConstants.PlayStateConstants.MenuTextQuit, regularFont, selectedFont),
            });

            return playGameOverMenu;
        }

        private void OnMainMenuSelectOnePlayer()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Change to play state with one active player
            _gameContext.StateMachine.AddState(
                new PlayState(
                    _gameContext,
                    new PlayStateGraphicsComponent(_gameContext),
                    new PlayStatePausedGraphicsComponent(_gameContext), 
                    new PlayStateGameOverGraphicsComponent(_gameContext), 
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GetReadySoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.IncomingSoundEffectName)),
                true);
        }

        private void OnMainMenuSelectTwoPlayer()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Change to play state with two active players
            _gameContext.StateMachine.AddState(
                new PlayState(
                    _gameContext,
                    new PlayStateGraphicsComponent(_gameContext),
                    new PlayStatePausedGraphicsComponent(_gameContext),
                    new PlayStateGameOverGraphicsComponent(_gameContext),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GameOverSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.GetReadySoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.PlayStateConstants.Audio.IncomingSoundEffectName)),
                true);
        }

        private void OnMainMenuSelectHelp()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuSelectionConfirmedSoundEffectName));
            //ToDo Change to help state
            _gameContext.StateMachine.AddState(new HelpMainMenuState(_gameContext, new HelpMainMenuStateGraphicsComponent(_gameContext)), false);
        }

        private void OnMainMenuSelectQuit()
        {
            _gameContext.QuitGame();
        }

        private void OnPlayStateSelectResume(TextMenu menu)
        {
            menu.IsEnabled = false;
        }

        private void OnPlayStateSelectHelp()
        {
            //ToDo Show help state
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphicsComponent(_gameContext)), false);
        }

        private void OnPlayStateSelectQuit()
        {
            var mainMenu = CreateMainMenu();
            //Go to main menu scene
            _gameContext.StateMachine.AddState(new MainMenuState(_gameContext, new MainMenuStateGraphicsComponent(_gameContext), mainMenu), true);
        }
    }
}