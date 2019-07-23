using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Notifications;
using SSSRegen.Source.Player;
using SSSRegen.Source.Projectiles;

namespace SSSRegen.Source.Enemies
{
    public class Enemy : GameObject, IEnemy
    {
        private readonly GameContext _gameContext;
        private readonly IHealthComponent _healthComponent;
        private readonly IComponent<IEnemy> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;
        private readonly int _initialMaxHealth;
        private readonly int _initialCollisionDamage;
        private readonly int _scoreValue;

        public Enemy(GameContext gameContext, int initialMaxHealth, int initialCollisionDamage, int scoreValue, IHealthComponent healthComponent, IComponent<IEnemy> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));

            _initialMaxHealth = initialMaxHealth;
            _initialCollisionDamage = initialCollisionDamage;
            _scoreValue = scoreValue;
        }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public int MaxHealth { get; private set; }
        public int CollisionDamageAmount { get; private set; }

        public IGameObject Target { get; private set; }

        public CollisionLayer CollisionLayer => CollisionLayer.Enemy;

        public override void Initialize()
        {
            MaxHealth = _initialMaxHealth;
            CollisionDamageAmount = _initialCollisionDamage;
            IsActive = true;
            Target = null;

            _physicsComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
            _healthComponent.Initialize(this);
            _healthComponent.Died += EnemyOnDied;
        }

        public override void Update(IGameTime gameTime)
        {
            float aggroRange = 600;
            if (PlayerManager.Player != null)
            {
                if (Vector2.Distance(PlayerManager.Player.Position, Position) < aggroRange &&
                    Position.Y < PlayerManager.Player.Position.Y && PlayerManager.Player.Position.X >= Position.X - aggroRange / 2 && PlayerManager.Player.Position.X <= Position.X + aggroRange / 2)
                {
                    Target = PlayerManager.Player;
                }
                else
                {
                    Target = null;
                }
            }
            else
            {
                Target = null;
            }
            

            _physicsComponent.Update(this, gameTime);
            _graphicsComponent.Update(this, gameTime);
            _healthComponent.Update(this, gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _graphicsComponent.Draw(this, gameTime);
            _healthComponent.Draw(this, gameTime);
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
                    //_gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.Projectiles.Bullet3.Audio.ShootSoundEffectName));
                    //Damage(meteor.CollisionDamageAmount);
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