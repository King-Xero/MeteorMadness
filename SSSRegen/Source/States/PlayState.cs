using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;
using SSSRegen.Source.Meteors;

namespace SSSRegen.Source.States
{
    public class PlayState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _playStateGraphics;
        private readonly IGameObjectManager[] _gameObjectManagers;

        private IGameMenu _playStateMenu;
        private bool _isTwoPlayer;
        private bool _isPaused;
        private bool _isGameOver;
        
        public PlayState(GameContext gameContext, IGraphicsComponent<IGameState> playStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playStateGraphics = playStateGraphics ?? throw new ArgumentNullException(nameof(playStateGraphics));
            _gameObjectManagers = new[]
            {
                new EnemiesManager(_gameContext.Factories.EnemyFactory),
                new MeteorsManager(_gameContext.Factories.MeteorsFactory),
                new BonusesManager(_gameContext.Factories.BonusesFactory),
                new PlayerManager(_gameContext.Factories.PlayerFactory)
            };
        }

        public override void Initialize()
        {
            _playStateGraphics.Initialize(this);
            _playStateMenu = _gameContext.Factories.MenuFactory.CreatePlayStateMenu();
            _playStateMenu.Initialize();

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Initialize();
            }

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _playStateGraphics.Update(this);
            _playStateMenu.Update(gameTime);

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Initialize();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _playStateGraphics.Draw(this);
            _playStateMenu.Draw(gameTime);

            foreach (var gameObjectManager in _gameObjectManagers)
            {
                gameObjectManager.Initialize();
            }

            base.Draw(gameTime);
        }
    }
}