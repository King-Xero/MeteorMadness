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

        public HealthPack(GameContext gameContext, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(physicsComponent, graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public CollisionLayer CollisionLayer => CollisionLayer.Bonus;
        public int CollisionDamageAmount => 0;

        public int HealAmount { get; private set; }

        public override void Initialize()
        {
            HealAmount = GameConstants.Bonuses.HealthPack.HealAmount;
            base.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            base.Draw(gameTime);
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