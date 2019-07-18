using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
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

        public Meteor CreateBigMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.BigMeteor1.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(_gameContext, new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.MediumMeteor1.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(_gameContext, new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.SmallMeteor1.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(_gameContext, new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }

        public Meteor CreateTinyMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.TinyMeteor1.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);
            return new Meteor(_gameContext, new MeteorPhysics(_gameContext, _random), graphicsComponent);
        }
    }
}