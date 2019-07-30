using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Bonuses
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
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.BonusConstants.HealthPackConstants.Textures.RedTextureName));
            var healthPackGraphics = new HealthPackGraphics(_gameContext.GameGraphics, sprite);
            return new HealthPack(_gameContext, new HealthPackPhysics(_gameContext, _random), healthPackGraphics);
        }
    }
}