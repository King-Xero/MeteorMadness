using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;

namespace SSSRegen.Source.Meteors
{
    public class MeteorFactory : IMeteorFactory
    {
        private readonly GameContext _gameContext;
        private readonly Random _random;

        public MeteorFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _random = gameContext.Random ?? throw new ArgumentNullException(nameof(gameContext.Random));
        }

        public Meteor CreateBigMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.BigMeteor1.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.Meteors.BigMeteor1.InitialMaxHealth,
                GameConstants.Meteors.BigMeteor1.CollisionDamage,
                GameConstants.Meteors.BigMeteor1.ScoreValue,
                new HealthComponent(GameConstants.Meteors.BigMeteor1.InitialMaxHealth, new NullHealthContainer()),
                new MeteorPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.MediumMeteor1.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.Meteors.MediumMeteor1.InitialMaxHealth,
                GameConstants.Meteors.MediumMeteor1.CollisionDamage,
                GameConstants.Meteors.MediumMeteor1.ScoreValue,
                new HealthComponent(GameConstants.Meteors.MediumMeteor1.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.SmallMeteor1.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.Meteors.SmallMeteor1.InitialMaxHealth,
                GameConstants.Meteors.SmallMeteor1.CollisionDamage,
                GameConstants.Meteors.SmallMeteor1.ScoreValue,
                new HealthComponent(GameConstants.Meteors.SmallMeteor1.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysics(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateTinyMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Meteors.TinyMeteor1.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphics(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.Meteors.TinyMeteor1.InitialMaxHealth,
                GameConstants.Meteors.TinyMeteor1.CollisionDamage,
                GameConstants.Meteors.TinyMeteor1.ScoreValue,
                new HealthComponent(GameConstants.Meteors.TinyMeteor1.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysics(_gameContext, _random),
                graphicsComponent);
        }
    }
}