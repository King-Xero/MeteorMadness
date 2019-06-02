using System;
using System.Linq;
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

        public MeteorFactory(GameContext gameContext, Random random)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName), GameConstants.Meteors.SmallMeteor.SpriteFrames.FirstOrDefault());
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(new NullInputComponent(), new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName), GameConstants.Meteors.MediumMeteor.SpriteFrames.FirstOrDefault());
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(new NullInputComponent(), new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }
    }
}