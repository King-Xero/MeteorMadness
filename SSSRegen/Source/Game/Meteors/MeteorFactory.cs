using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;

namespace SSSRegen.Source.Game.Meteors
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
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.ScoreValue,
                MeteorType.Big,
                new HealthComponent(GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.InitialMaxHealth, new NullHealthContainer()),
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.ScoreValue,
                MeteorType.Medium,
                new HealthComponent(GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.ScoreValue,
                MeteorType.Small,
                new HealthComponent(GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateTinyMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.ScoreValue,
                MeteorType.Tiny,
                new HealthComponent(GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }
    }
}