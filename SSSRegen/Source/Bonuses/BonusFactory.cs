using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusFactory : IBonusFactory
    {
        private readonly Game _game;
        private readonly Random _random;
        private readonly ISpriteBatch _spriteBatch;
        private Texture2D _spriteSheet;

        public BonusFactory(Game game, Random random, ISpriteBatch spriteBatch, ref Texture2D spriteSheet)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public HealthPack CreateHealthPack()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Bonuses.HealthPack.SpriteFrames, GameConstants.Bonuses.HealthPack.FrameDelay);
            return new HealthPack(_game, _random, sprite);
        }
    }
}