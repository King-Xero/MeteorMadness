using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorFactory : IMeteorFactory
    {
        private readonly Game _game;
        private readonly Random _random;
        private Texture2D _spriteSheet;

        public MeteorFactory(Game game, Random random, ref Texture2D spriteSheet)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Meteor CreateSmallMeteor()
        {
            return new Meteor(_game, _random, ref _spriteSheet, GameConstants.Meteors.SmallMeteor.SpriteFrames);
        }

        public Meteor CreateMediumMeteor()
        {
            return new Meteor(_game, _random, ref _spriteSheet, GameConstants.Meteors.MediumMeteor.SpriteFrames);
        }
    }
}