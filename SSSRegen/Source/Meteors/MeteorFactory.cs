using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorFactory : IMeteorFactory
    {
        private readonly Game _game;
        private readonly Random _random;
        private readonly ISpriteBatch _spriteBatch;
        private Texture2D _spriteSheet;

        public MeteorFactory(Game game, Random random, ISpriteBatch spriteBatch, ref Texture2D spriteSheet)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Meteors.SmallMeteor.SpriteFrames, 0);
            return new Meteor(_game, _random, sprite);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_spriteBatch, ref _spriteSheet, GameConstants.Meteors.MediumMeteor.SpriteFrames, 0);
            return new Meteor(_game, _random, sprite);
        }
    }
}