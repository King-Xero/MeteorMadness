using System;
using SSSRegen.Source.Core.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Menus;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.States
{
    public class MainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IDrawableComponent<IGameState> _mainMenuStateGraphics;
        private readonly IGameMenu _textMenu;
        
        public MainMenuState(GameContext gameContext, IDrawableComponent<IGameState> mainMenuStateGraphics, IGameMenu textMenu)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _mainMenuStateGraphics = mainMenuStateGraphics ?? throw new ArgumentNullException(nameof(mainMenuStateGraphics));
            _textMenu = textMenu ?? throw new ArgumentNullException(nameof(textMenu));
        }

        public override void Initialize()
        {
            _mainMenuStateGraphics.Initialize(this);
            _textMenu.Initialize();
            base.Initialize();

            _gameContext.GameAudio.StopMusic();
            _gameContext.GameAudio.PlayMusic(_gameContext.AssetManager.GetSong(GameConstants.GameStateConstants.MenuStateConstants.Audio.BackgroundMusicName), true);
        }

        public override void Update(IGameTime gameTime)
        {
            _mainMenuStateGraphics.Update(this, gameTime);

            _textMenu.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _mainMenuStateGraphics.Draw(this, gameTime);

            _textMenu.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}