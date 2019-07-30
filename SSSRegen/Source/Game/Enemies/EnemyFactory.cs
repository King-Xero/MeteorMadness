using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly GameContext _gameContext;
        private readonly PlayerManager _playerManager;
        private readonly Random _random;

        public EnemyFactory(GameContext gameContext, PlayerManager playerManager)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playerManager = playerManager ?? throw new ArgumentNullException(nameof(playerManager));
            _random = gameContext.Random ?? throw new ArgumentNullException(nameof(gameContext.Random));
        }

        public Enemy CreateEnemy1()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.EnemyConstants.Enemy1Constants.Textures.BlackTextureName));

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            //ToDo pass in enemy strategy instead of multiple config values
            return new Enemy(
                _gameContext,
                GameConstants.EnemyConstants.Enemy1Constants.InitialMaxHealth,
                GameConstants.EnemyConstants.Enemy1Constants.CollisionDamage,
                GameConstants.EnemyConstants.Enemy1Constants.ScoreValue,
                GameConstants.EnemyConstants.Enemy1Constants.AggroRange,
                new HealthComponent(GameConstants.EnemyConstants.Enemy1Constants.InitialMaxHealth, new NullHealthContainer()),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent,
                _playerManager);
        }

        public Enemy CreateEnemy2()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.EnemyConstants.Enemy2Constants.Textures.BlueTextureName));

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                _gameContext,
                GameConstants.EnemyConstants.Enemy2Constants.InitialMaxHealth,
                GameConstants.EnemyConstants.Enemy2Constants.CollisionDamage,
                GameConstants.EnemyConstants.Enemy2Constants.ScoreValue,
                GameConstants.EnemyConstants.Enemy2Constants.AggroRange,
                new HealthComponent(GameConstants.EnemyConstants.Enemy2Constants.InitialMaxHealth, new NullHealthContainer()),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent,
                _playerManager);
        }

        public Enemy CreateEnemy3()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.EnemyConstants.Enemy3Constants.Textures.GreenTextureName));

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                _gameContext,
                GameConstants.EnemyConstants.Enemy3Constants.InitialMaxHealth,
                GameConstants.EnemyConstants.Enemy3Constants.CollisionDamage,
                GameConstants.EnemyConstants.Enemy3Constants.ScoreValue,
                GameConstants.EnemyConstants.Enemy3Constants.AggroRange,
                new HealthComponent(GameConstants.EnemyConstants.Enemy3Constants.InitialMaxHealth, new NullHealthContainer()),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent,
                _playerManager);
        }

        //ToDo Create more enemy types
    }
}