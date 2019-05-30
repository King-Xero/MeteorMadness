using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorFactory : IMeteorFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Texture2D _spriteSheet;

        public MeteorFactory(GameContext gameContext, Random random,ref Texture2D spriteSheet)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Meteors.SmallMeteor.SpriteFrames.FirstOrDefault());
            return new Meteor(new NullInputComponent(), new MeteorPhysics(_gameContext, _random), new MeteorGraphics());
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Meteors.MediumMeteor.SpriteFrames.FirstOrDefault());
            return new Meteor(new NullInputComponent(), new MeteorPhysics(_gameContext, _random), new MeteorGraphics());
        }
    }
}