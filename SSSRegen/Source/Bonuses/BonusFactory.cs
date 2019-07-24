using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusFactory : IBonusFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public BonusFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = gameContext.Random ?? throw new ArgumentNullException(nameof(gameContext.Random));
        }

        public HealthPack CreateHealthPack()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Bonuses.HealthPack.Textures.RedTextureName));
            var healthPackGraphics = new HealthPackGraphics(_gameContext.GameGraphics, sprite);
            return new HealthPack(_gameContext, new HealthPackPhysics(_gameContext, _random), healthPackGraphics);
        }
    }
}