using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusFactory : IBonusFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;
        private Texture2D _spriteSheet;

        public BonusFactory(GameContext gameContext, Random random, ref Texture2D spriteSheet)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _spriteSheet = spriteSheet ?? throw new ArgumentNullException(nameof(spriteSheet));
        }

        public HealthPack CreateHealthPack()
        {
            var sprite = new Sprite(ref _spriteSheet, GameConstants.Bonuses.HealthPack.SpriteFrames.FirstOrDefault());
            return new HealthPack(new NullInputComponent(), new HealthPackPhysics(_gameContext, _random), new HealthPackGraphics());
        }
    }
}