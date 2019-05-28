using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Game _game;
        private readonly Random _random;
        private readonly ISpriteBatch _spriteBatch;
        private Texture2D _spriteSheet;

        public EnemyFactory(Game game, Random random, ISpriteBatch spriteBatch, ref Texture2D spriteSheet)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Enemy CreateEnemy1()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Enemies.Enemy1.SpriteFrames, 0);
            return new Enemy(_game, _random, sprite);
        }

        public Enemy CreateEnemy2()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Enemies.Enemy2.SpriteFrames, 0);
            return new Enemy(_game, _random, sprite);
        }

        public Enemy CreateEnemy3()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Enemies.Enemy3.SpriteFrames, 0);
            return new Enemy(_game, _random, sprite);
        }

        public Enemy CreateEnemyBoss()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Enemies.EnemyBoss.SpriteFrames, 0);
            return new Enemy(_game, _random, sprite);
        }
    }
}