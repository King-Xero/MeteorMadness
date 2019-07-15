using System;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Player;

namespace SSSRegen.Source.States
{
    public class PlayState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IDrawableComponent<IGameState> _playStateGraphics;
        private readonly IGameObjectManager[] _gameObjectManagers;

        private IGameMenu _playStateMenu;
        private bool _isTwoPlayer;
        private bool _isPaused;
        private bool _isGameOver;
        
        public PlayState(GameContext gameContext, IDrawableComponent<IGameState> playStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playStateGraphics = playStateGraphics ?? throw new ArgumentNullException(nameof(playStateGraphics));
            _gameObjectManagers = new IGameObjectManager[]
            {
                new EnemiesManager(_gameContext.Factories.EnemyFactory, _gameContext.CollisionSystem),
                new MeteorsManager(_gameContext.Factories.MeteorsFactory, _gameContext.CollisionSystem),
                new BonusManager(_gameContext.Factories.BonusesFactory, _gameContext.CollisionSystem),
                new PlayerManager(_gameContext.Factories.PlayerFactory, _gameContext.CollisionSystem)
            };
        }

        public override void Initialize()
        {
            _gameContext.GameAudio.StopMusic();
            _gameContext.GameAudio.PlayMusic(_gameContext.AssetManager.GetSong(GameConstants.GameStates.PlayState.Audio.BackgroundMusicName), true);

            _gameContext.CollisionSystem.Initialize();
            _playStateGraphics.Initialize(this);
            _playStateMenu = _gameContext.Factories.MenuFactory.CreatePlayStateMenu();
            _playStateMenu.Initialize();
            _playStateMenu.IsEnabled = false;

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Initialize();
            }

            base.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            _gameContext.CollisionSystem.Update(gameTime);

            _playStateGraphics.Update(this, gameTime);
            _playStateMenu.Update(gameTime);

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _playStateGraphics.Draw(this, gameTime);
            _playStateMenu.Draw(gameTime);

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}