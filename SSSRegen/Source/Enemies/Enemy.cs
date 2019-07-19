using System;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Notifications;
using SSSRegen.Source.Projectiles;

namespace SSSRegen.Source.Enemies
{
    public class Enemy : GameObject, IHandleHealth, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private readonly IHealthComponent _healthComponent;
        private readonly int _initialMaxHealth;
        private readonly int _initialCollisionDamage;
        private readonly int _scoreValue;

        public Enemy(GameContext gameContext, int initialMaxHealth, int initialCollisionDamage, int scoreValue, IHealthComponent healthComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(physicsComponent, graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));

            _initialMaxHealth = initialMaxHealth;
            _initialCollisionDamage = initialCollisionDamage;
            _scoreValue = scoreValue;
        }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public int MaxHealth { get; private set; }
        public int CollisionDamageAmount { get; private set; }

        public CollisionLayer CollisionLayer => CollisionLayer.Enemy;

        public override void Initialize()
        {
            MaxHealth = _initialMaxHealth;
            CollisionDamageAmount = _initialCollisionDamage;
            IsActive = true;
            //Target = null;

            _healthComponent.Initialize(this);
            _healthComponent.Died += EnemyOnDied;

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
                case Player.Player player:
                    //ToDo swap for appropriate sfx (enemy collided with player)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(player.CollisionDamageAmount);
                    break;
                case Bullet bullet:
                    //ToDo swap for appropriate sfx (enemy collided with bullet)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(bullet.CollisionDamageAmount);
                    break;
                case HealthPack healthPack:
                    break;
                case Enemy enemy:
                    //ToDo do something here to stop enemies overlapping
                    break;
                case Meteor meteor:
                    //ToDo swap for appropriate sfx (enemy collided with meteor)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    Damage(meteor.CollisionDamageAmount);
                    break;
            }
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
        }

        private void EnemyOnDied(object sender, EventArgs e)
        {
            //Enemy died
            //ToDo play destroyed sound
            //_gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));

            _gameContext.NotificationMediator.PublishPlayerScoreChange(new PlayerScoreNotificationArguments(_scoreValue));
            _healthComponent.Died -= EnemyOnDied;
            IsActive = false;
        }
    }
}