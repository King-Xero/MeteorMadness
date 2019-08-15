using System;
using Microsoft.Xna.Framework.Audio;
using SSSRegen.Source.Core.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Menus;
using SSSRegen.Source.Game.Bonuses;
using SSSRegen.Source.Game.Enemies;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Meteors;
using SSSRegen.Source.Game.Player;
using SSSRegen.Source.Game.Score;

namespace SSSRegen.Source.Game.States
{
    public class PlayState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IDrawableComponent<IGameState> _playStateGraphics;
        private readonly SoundEffect _pauseMenuAppearingSoundEffect;
        private readonly SoundEffect _pauseMenuDisappearingSoundEffect;
        private readonly IGameObjectManager[] _gameObjectManagers;
        private readonly IScoreComponent _scoreComponent;

        private IGameMenu _playStateMenu;
        private bool _isPaused;
        private bool _isTwoPlayer;
        private bool _isGameOver;

        private bool IsPaused
        {
            get => _isPaused;
            set
            {
                if (_isPaused == value) return;

                _isPaused = value;

                if (_isPaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
        
        public PlayState(GameContext gameContext, IDrawableComponent<IGameState> playStateGraphics, SoundEffect pauseMenuAppearingSoundEffect, SoundEffect pauseMenuDisappearingSoundEffect)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playStateGraphics = playStateGraphics ?? throw new ArgumentNullException(nameof(playStateGraphics));
            _pauseMenuAppearingSoundEffect = pauseMenuAppearingSoundEffect ?? throw new ArgumentException(nameof(pauseMenuAppearingSoundEffect));
            _pauseMenuDisappearingSoundEffect = pauseMenuDisappearingSoundEffect ?? throw new ArgumentException(nameof(pauseMenuDisappearingSoundEffect));

            var playerManager = new PlayerManager(new PlayerFactory(_gameContext), _gameContext.CollisionSystem);

            _gameObjectManagers = new IGameObjectManager[]
            {
                playerManager,
                //ToDo Change how enemies are spawned and positioned
                //new EnemiesManager(new EnemyFactory(_gameContext, playerManager), _gameContext.CollisionSystem),
                new MeteorsManager(_gameContext, new MeteorFactory(_gameContext), _gameContext.CollisionSystem),
                new BonusManager(_gameContext, new BonusFactory(_gameContext), _gameContext.CollisionSystem),
            };

            _scoreComponent = new PlayerScoreComponent(_gameContext);
        }

        public override void Initialize()
        {
            _gameContext.GameAudio.StopMusic();
            _gameContext.GameAudio.PlayMusic(_gameContext.AssetManager.GetSong(GameConstants.GameStateConstants.PlayStateConstants.Audio.BackgroundMusicName), true);

            //ToDo move collision system out of GameContext. Make local to play state.
            _gameContext.CollisionSystem.Initialize();

            _scoreComponent.Initialize();

            _playStateGraphics.Initialize(this);
            _playStateMenu = _gameContext.MenuFactory.CreatePlayStateMenu();
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
            IsPaused = _playStateMenu.IsEnabled;
            
            _playStateMenu.Update(gameTime);
            _gameContext.CollisionSystem.Update(gameTime);
            _playStateGraphics.Update(this, gameTime);
            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Update(gameTime);
            }
            _scoreComponent.Update();

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _playStateGraphics.Draw(this, gameTime);
            
            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Draw(gameTime);
            }

            _scoreComponent.Draw();

            _playStateMenu.Draw(gameTime);

            base.Draw(gameTime);
        }

        private void PauseGame()
        {
            _gameContext.GameAudio.PauseAllAudio();
            _gameContext.GameAudio.PlaySoundEffect(_pauseMenuAppearingSoundEffect);

            _gameContext.CollisionSystem.Pause();
            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Pause();
            }
        }

        private void ResumeGame()
        {
            _gameContext.GameAudio.PlaySoundEffect(_pauseMenuDisappearingSoundEffect);
            _gameContext.GameAudio.ResumeAllAudio();

            _gameContext.CollisionSystem.Resume();
            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Resume();
            }
        }
    }
}