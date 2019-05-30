using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Texture2D _spriteSheet;

        public EnemyFactory(GameContext gameContext, Random random, ref Texture2D spriteSheet)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Enemy CreateEnemy1()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Enemies.Enemy1.SpriteFrames.FirstOrDefault());
            return new Enemy(new NullInputComponent(), new EnemyPhysics(_gameContext, _random), new EnemyGraphics());
        }

        public Enemy CreateEnemy2()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Enemies.Enemy2.SpriteFrames.FirstOrDefault());
            return new Enemy(new NullInputComponent(), new EnemyPhysics(_gameContext, _random), new EnemyGraphics());
        }

        public Enemy CreateEnemy3()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Enemies.Enemy3.SpriteFrames.FirstOrDefault());
            return new Enemy(new NullInputComponent(), new EnemyPhysics(_gameContext, _random), new EnemyGraphics());
        }

        public Enemy CreateEnemyBoss()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Enemies.EnemyBoss.SpriteFrames.FirstOrDefault());
            return new Enemy(new NullInputComponent(), new EnemyPhysics(_gameContext, _random), new EnemyGraphics());
        }
    }
}