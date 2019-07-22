using System;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Projectiles
{
    public class Bullet : GameObject, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private bool _isActive;

        public Bullet(GameContext gameContext, int damageAmount, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) : base(physicsComponent, graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));

            CollisionDamageAmount = damageAmount;
        }

        public override bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (_isActive)
                {
                    PlaySoundEffect();
                }
            }
        }

        public CollisionLayer CollisionLayer => CollisionLayer.Player;
        public int CollisionDamageAmount { get; private set; }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
            IsActive = false;
        }

        private void PlaySoundEffect()
        {
            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
        }
    }
}