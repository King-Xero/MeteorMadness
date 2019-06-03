using System;
using System.Linq;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;

namespace SSSRegen.Source.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public EnemyFactory(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Enemy CreateEnemy1()
        {
            var sprite = new Sprite(
                _gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName),
                GameConstants.Enemies.Enemy1.SpriteFrames.FirstOrDefault());

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                new EnemyHealthComponent(GameConstants.Enemies.Enemy1.InitialMaxHealth, new NullHealthContainer()),
                new NullGameObjectInputComponent(),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Enemy CreateEnemy2()
        {
            var sprite = new Sprite(
                _gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName),
                GameConstants.Enemies.Enemy2.SpriteFrames.FirstOrDefault());

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                new EnemyHealthComponent(GameConstants.Enemies.Enemy2.InitialMaxHealth, new NullHealthContainer()),
                new NullGameObjectInputComponent(),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Enemy CreateEnemy3()
        {
            var sprite = new Sprite(
                _gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName),
                GameConstants.Enemies.Enemy3.SpriteFrames.FirstOrDefault());

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                new EnemyHealthComponent(GameConstants.Enemies.Enemy3.InitialMaxHealth, new NullHealthContainer()),
                new NullGameObjectInputComponent(),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Enemy CreateEnemyBoss()
        {
            var sprite = new Sprite(
                _gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName),
                GameConstants.Enemies.EnemyBoss.SpriteFrames.FirstOrDefault());

            var graphicsComponent = new EnemyGraphics(_gameContext.GameGraphics, sprite);

            return new Enemy(
                new EnemyHealthComponent(GameConstants.Enemies.EnemyBoss.InitialMaxHealth, new NullHealthContainer()),
                new NullGameObjectInputComponent(),
                new EnemyPhysics(_gameContext, _random),
                graphicsComponent);
        }
    }
}