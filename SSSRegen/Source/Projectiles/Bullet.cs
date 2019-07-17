using System;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Meteors;

namespace SSSRegen.Source.Projectiles
{
    public class Bullet : GameObject, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private bool _isActive;

        public Bullet(GameContext gameContext, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) : base(physicsComponent, graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
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