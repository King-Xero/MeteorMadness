﻿using System;
using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.Entities;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Projectiles
{
    public class Bullet : GameObject, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private readonly IComponent<IGameObject> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;

        private bool _isActive;

        public Bullet(GameContext gameContext, int damageAmount, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));

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

        public override void Initialize()
        {
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

        public CollisionLayer CollisionLayer => CollisionLayer.PlayerProjectile;
        public int CollisionDamageAmount { get; }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            if (gameObject.CollisionLayer == CollisionLayer.Player || gameObject.CollisionLayer == CollisionLayer.Bonus)
            {
                return;
            }
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
            IsActive = false;
        }

        private void PlaySoundEffect()
        {
            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.ProjectileConstants.Bullet3Constants.Audio.ShootSoundEffectName));
        }
    }
}