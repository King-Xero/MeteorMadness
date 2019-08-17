using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Meteors.Strategies;

namespace SSSRegen.Source.Game.Meteors
{
    public class MeteorFactory : IMeteorFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        private readonly IMeteorStrategy _bigMeteorStrategy, _mediumMeteorStrategy, _smallMeteorStrategy, _tinyMeteorStrategy;
        private readonly ISprite _bigMeteorSprite, _mediumMeteorSprite, _smallMeteorSprite, _tinyMeteorSprite;

        public MeteorFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = gameContext.Random ?? throw new ArgumentNullException(nameof(gameContext.Random));
            _bigMeteorStrategy = new BigMeteorStrategy();
            _mediumMeteorStrategy = new MediumMeteorStrategy();
            _smallMeteorStrategy = new SmallMeteorStrategy();
            _tinyMeteorStrategy = new TinyMeteorStrategy();

            _bigMeteorSprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Textures.BrownTextureName));
            _mediumMeteorSprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Textures.BrownTextureName));
            _smallMeteorSprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Textures.GreyTextureName));
            _tinyMeteorSprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Textures.GreyTextureName));
        }

        public Meteor CreateBigMeteor()
        {
            return new Meteor(
                _gameContext,
                _bigMeteorStrategy,
                new HealthComponent(new NullHealthContainer()),
                new MeteorPhysicsComponent(_gameContext, _random),
                new MeteorGraphicsComponent(_gameContext.GameGraphics, _bigMeteorSprite));
        }

        public Meteor CreateMediumMeteor()
        {
            return new Meteor(
                _gameContext,
                _mediumMeteorStrategy,
                new HealthComponent(new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                new MeteorGraphicsComponent(_gameContext.GameGraphics, _mediumMeteorSprite));
        }

        public Meteor CreateSmallMeteor()
        {
            return new Meteor(
                _gameContext,
                _smallMeteorStrategy,
                new HealthComponent(new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                new MeteorGraphicsComponent(_gameContext.GameGraphics, _smallMeteorSprite));
        }

        public Meteor CreateTinyMeteor()
        {
            return new Meteor(
                _gameContext,
                _tinyMeteorStrategy,
                new HealthComponent(new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                new MeteorGraphicsComponent(_gameContext.GameGraphics, _tinyMeteorSprite));
        }
    }
}