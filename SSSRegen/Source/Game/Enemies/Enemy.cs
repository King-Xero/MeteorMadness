using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.Entities;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.Bonuses;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Meteors;
using SSSRegen.Source.Game.Notifications;
using SSSRegen.Source.Game.Player;
using SSSRegen.Source.Game.Projectiles;

namespace SSSRegen.Source.Game.Enemies
{
    public class Enemy : GameObject, IEnemy
    {
        private readonly GameContext _gameContext;
        private readonly IHealthComponent _healthComponent;
        private readonly IComponent<IEnemy> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;
        private readonly PlayerManager _playerManager;

        private readonly int _initialMaxHealth;
        private readonly int _initialCollisionDamage;
        private readonly int _scoreValue;
        private readonly float _aggroRange;

        public Enemy(GameContext gameContext, int initialMaxHealth, int initialCollisionDamage, int scoreValue, float aggroRange, IHealthComponent healthComponent, IComponent<IEnemy> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent, PlayerManager playerManager)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
            _playerManager = playerManager ?? throw new ArgumentNullException(nameof(playerManager));

            _initialMaxHealth = initialMaxHealth;
            _initialCollisionDamage = initialCollisionDamage;
            _scoreValue = scoreValue;
            _aggroRange = aggroRange;
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
            //ToDo move this logic out of the enemy classS
            if (_playerManager.Player != null)
            {
                if (Vector2.Distance(_playerManager.Player.Position, Position) < _aggroRange &&
                    Position.Y < _playerManager.Player.Position.Y && _playerManager.Player.Position.X >= Position.X - _aggroRange / 2 && _playerManager.Player.Position.X <= Position.X + _aggroRange / 2)
                {
                    Target = _playerManager.Player;
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
                      _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.ProjectileConstants.Bullet3Constants.Audio.ShootSoundEffectName));
                    Damage(player.CollisionDamageAmount);
                    break;
                case Bullet bullet:
                    //ToDo swap for appropriate sfx (enemy collided with bullet)
                    _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.ProjectileConstants.Bullet3Constants.Audio.ShootSoundEffectName));
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