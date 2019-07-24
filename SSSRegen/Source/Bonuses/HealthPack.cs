using System;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class HealthPack : GameObject, IHandleCollisions, IHealthPack
    {
        private readonly GameContext _gameContext;
        private readonly IComponent<IGameObject> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;

        public HealthPack(GameContext gameContext, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }

        public CollisionLayer CollisionLayer => CollisionLayer.Bonus;
        public int CollisionDamageAmount => 0;

        public int HealAmount { get; private set; }

        public override void Initialize()
        {
            HealAmount = GameConstants.Bonuses.HealthPack.HealAmount;

            _physicsComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
        }

        public override void Update(IGameTime gameTime)
        {
            _physicsComponent.Update(this, gameTime);
            _graphicsComponent.Update(this, gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _graphicsComponent.Draw(this, gameTime);
        }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");

            //ToDo Assign and use collision layers
            if (gameObject.CollisionLayer == CollisionLayer.Player)
            {
                IsActive = false;
                PlayCollectedSoundEffect();
            }
        }

        private void PlayCollectedSoundEffect()
        {
            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Bonuses.HealthPack.Audio.CollectedSoundEffectName));
        }
    }

    public interface IHealthPack
    {
        int HealAmount { get; }
    }
}