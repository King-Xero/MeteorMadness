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

            var mainMenu = new TextMenu(_gameContext, new GameMenuInput(new KeyboardInputController()),
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

        public IGameMenu CreatePlayStateMenu()
        {
            var regularFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.RegularFontName);
            var selectedFont = _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName);

            var playMenu = new TextMenu(_gameContext, new PlayStateMenuInput(new KeyboardInputController()),
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuNavigateSoundEffectName));

            playMenu.SetMenuItems(new List<IMenuOption>()
            {
                new TextMenuOption(_gameContext, () => OnPlayStateSelectResume(playMenu), GameConstants.GameStateConstants.PlayStateConstants.MenuTextResume, regularFont, selectedFont),
                //new TextMenuOption(_gameContext, OnPlayStateSelectHelp, GameConstants.GameStates.PlayState.MenuTextHelp, regularFont, selectedFont),
                new TextMenuOption(_gameContext, OnPlayStateSelectQuit, GameConstants.GameStateConstants.PlayStateConstants.MenuTextQuit, regularFont, selectedFont),
            });

            return playMenu;
        }

        private void OnMainMenuSelectOnePlayer()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectName));
            //ToDo Change to play state with one active player
            _gameContext.StateMachine.AddState(
                new PlayState(
                    _gameContext,
                    new PlayStateGraphics(_gameContext),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectName)),
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
                    new PlayStateGraphics(_gameContext),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuOpenedSoundEffectName),
                    _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.ModalMenuClosedSoundEffectName)),
                true);
        }

        private void OnMainMenuSelectHelp()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.MenuSelectionConfirmedSoundEffectName));
            //ToDo Change to help state
            _gameContext.StateMachine.AddState(new HelpMainMenuState(_gameContext, new HelpMainMenuStateGraphics(_gameContext)), false);
        }

        private void OnMainMenuSelectQuit()
        {
            _gameContext.GameAudio.PlaySoundEffect(
                _gameContext.AssetManager.GetSoundEffect(GameConstants.GameStateConstants.MenuStateConstants.Audio.NewStateSelectionConfirmedSoundEffectName));
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