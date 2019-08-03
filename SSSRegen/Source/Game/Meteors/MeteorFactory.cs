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
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.BigMeteor1Constants.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.BigMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.BigMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.BigMeteor1Constants.ScoreValue,
                new HealthComponent(GameConstants.MeteorConstants.BigMeteor1Constants.InitialMaxHealth, new NullHealthContainer()),
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateMediumMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.MediumMeteor1Constants.Textures.BrownTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.MediumMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.MediumMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.MediumMeteor1Constants.ScoreValue,
                new HealthComponent(GameConstants.MeteorConstants.MediumMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateSmallMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.SmallMeteor1Constants.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.SmallMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.SmallMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.SmallMeteor1Constants.ScoreValue,
                new HealthComponent(GameConstants.MeteorConstants.SmallMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }

        public Meteor CreateTinyMeteor()
        {
            var sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.MeteorConstants.TinyMeteor1Constants.Textures.GreyTextureName));
            var graphicsComponent = new MeteorGraphicsComponent(_gameContext.GameGraphics, sprite);

            return new Meteor(
                _gameContext,
                GameConstants.MeteorConstants.TinyMeteor1Constants.InitialMaxHealth,
                GameConstants.MeteorConstants.TinyMeteor1Constants.CollisionDamage,
                GameConstants.MeteorConstants.TinyMeteor1Constants.ScoreValue,
                new HealthComponent(GameConstants.MeteorConstants.TinyMeteor1Constants.InitialMaxHealth, new NullHealthContainer()), 
                new MeteorPhysicsComponent(_gameContext, _random),
                graphicsComponent);
        }
    }
}