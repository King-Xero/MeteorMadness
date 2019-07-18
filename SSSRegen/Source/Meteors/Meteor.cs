﻿using System;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Projectiles;

namespace SSSRegen.Source.Meteors
{
    public class Meteor : GameObject, IHandleHealth, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private readonly int _initialMaxHealth;
        private readonly int _initialCollisionDamage;
        private readonly IHealthComponent _healthComponent;

        public Meteor(GameContext gameContext, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(physicsComponent, graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }
        
        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public int MaxHealth { get; private set; }
        public int CollisionDamageAmount { get; private set; }
        public CollisionLayer CollisionLayer => CollisionLayer.Meteor;

        public override void Initialize()
        {
            MaxHealth = _initialMaxHealth;
            CollisionDamageAmount = _initialCollisionDamage;
            IsActive = true;

            _healthComponent.Initialize(this);
            _healthComponent.Died += MeteorOnDied;

            base.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            _healthComponent.Update(this);

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _healthComponent.Draw(this);

            base.Draw(gameTime);
        }

        public void Heal(int healAmount)
        {
            Healed?.Invoke(this, new HealEventArgs(healAmount));
        }

        public void Damage(int damageAmount)
        {
            Damaged?.Invoke(this, new DamageEventArgs(damageAmount));
        }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            switch (gameObject)
            {
                case Source.Player.Player player:
                    //ToDo swap for appropriate sfx (meteor collided with player)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(player.CollisionDamageAmount);
                    break;
                case Bullet bullet:
                    //ToDo swap for appropriate sfx (meteor collided with bullet)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(bullet.CollisionDamageAmount);
                    break;
                case HealthPack healthPack:
                    break;
                case Meteor meteor:
                    //ToDo do something here to stop meteors overlapping
                    break;
                case Enemy enemy:
                    //ToDo swap for appropriate sfx (meteor collided with enemy)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(enemy.CollisionDamageAmount);
                    break;
            }
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
        }

        private void MeteorOnDied(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Meteor destroyed
        }
    }
}