using System;
using System.Collections.Generic;
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

            var mainMenu = new TextMenu(_gameContext, new GameMenuInput(new KeyboardInputController()),
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.MenuNavigateSoundEffectName));

            mainMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, OnMainMenuSelectOnePlayer, GameConstants.GameStates.MenuState.PlayMenuText, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnMainMenuSelectTwoPlayer, GameConstants.GameStates.MenuState.TwoPlayerMenuText, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnMainMenuSelectHelp, GameConstants.GameStates.MenuState.HelpMenuText, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnMainMenuSelectQuit, GameConstants.GameStates.MenuState.QuitMenuText, regularFont, selectedFont),
            });

            return mainMenu;
        }

        public IGameMenu CreatePlayStateMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.SelectedFontName);

            var playMenu = new TextMenu(_gameContext, new PlayStateMenuInput(new KeyboardInputController()),
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.MenuNavigateSoundEffectName));

            playMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, () => OnPlayStateSelectResume(playMenu), GameConstants.GameStates.PlayState.MenuTextResume, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnPlayStateSelectHelp, GameConstants.GameStates.PlayState.MenuTextHelp, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectQuit, GameConstants.GameStates.PlayState.MenuTextQuit, regularFont, selectedFont),
            });

            return playMenu;
        }

        private void OnMainMenuSelectOnePlayer()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Change to play state with one active player
            _gameContext.StateMachine.AddState(
                new PlayState(
                    _gameContext,
                    new PlayStateGraphics(_gameContext),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.ModalMenuClosedSoundEffectName)),
                true);
        }

        private void OnMainMenuSelectTwoPlayer()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Change to play state with two active players
            _gameContext.StateMachine.AddState(
                new PlayState(
                    _gameContext,
                    new PlayStateGraphics(_gameContext),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.ModalMenuClosedSoundEffectName)),
                true);
        }

        private void OnMainMenuSelectHelp()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.MenuSelectionConfirmedSoundEffectName));
            //ToDo Change to help state
            _gameContext.StateMachine.AddState(new HelpMainMenuState(_gameContext, new HelpMainMenuStateGraphics(_gameContext)), false);
        }

        private void OnMainMenuSelectQuit()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStates.MenuState.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Close game
            throw new NotImplementedException();
        }

        private void OnPlayStateSelectResume(TextMenu menu)
        {
            menu.IsEnabled = false;
        }

        private void OnPlayStateSelectHelp()
        {
            //ToDo Show help state
            _gameContext.StateMachine.AddState(new SplashState(_gameContext, new SplashStateGraphics(_gameContext)), false);
        }

        private void OnPlayStateSelectQuit()
        {
            var mainMenu = CreateMainMenu();
            //Go to main menu scene
            _gameContext.StateMachine.AddState(new MainMenuState(_gameContext, new MainMenuStateGraphics(_gameContext), mainMenu), true);
        }
    }
}