using System;
using System.Linq;
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

        public BonusFactory(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public HealthPack CreateHealthPack()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName), GameConstants.Bonuses.HealthPack.SpriteFrames.FirstOrDefault());
            var healthPackGraphics = new HealthPackGraphics(_gameContext.GameGraphics, sprite);
            return new HealthPack(new NullInputComponent(), new HealthPackPhysics(_gameContext, _random), healthPackGraphics);
        }
    }
}