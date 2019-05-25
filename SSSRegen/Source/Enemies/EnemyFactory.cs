using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Game _game;
        private readonly Random _random;
        private Texture2D _spriteSheet;

        public EnemyFactory(Game game, Random random, ref Texture2D spriteSheet)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Enemy CreateEnemy1()
        {
            return new Enemy(_game, _random, ref _spriteSheet, GameConstants.Enemies.Enemy1.SpriteFrames);
        }

        public Enemy CreateEnemy2()
        {
            return new Enemy(_game, _random, ref _spriteSheet, GameConstants.Enemies.Enemy2.SpriteFrames);
        }

        public Enemy CreateEnemy3()
        {
            return new Enemy(_game, _random, ref _spriteSheet, GameConstants.Enemies.Enemy3.SpriteFrames);
        }

        public Enemy CreateEnemyBoss()
        {
            return new Enemy(_game, _random, ref _spriteSheet, GameConstants.Enemies.EnemyBoss.SpriteFrames);
        }
    }
}