using System;
using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.Entities;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.Bonuses;
using SSSRegen.Source.Game.Enemies;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Meteors.Strategies;
using SSSRegen.Source.Game.Notifications;
using SSSRegen.Source.Game.Projectiles;

namespace SSSRegen.Source.Game.Meteors
{
    public class Meteor : GameObject, IHandleHealth, IHandleCollisions
    {
        private readonly GameContext _gameContext;
        private readonly IMeteorStrategy _meteorStrategy;
        private readonly IHealthComponent _healthComponent;
        private readonly IComponent<IGameObject> _physicsComponent;
        private readonly IDrawableComponent<IGameObject> _graphicsComponent;
        
        
        public Meteor(GameContext gameContext, IMeteorStrategy meteorStrategy, IHealthComponent healthComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _meteorStrategy = meteorStrategy ?? throw new ArgumentNullException(nameof(meteorStrategy));
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
        }
        
        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public float CurrentHealth => _healthComponent.CurrentHealth;
        public float MaxHealth => _healthComponent.MaxHealth;

        public int CollisionDamageAmount { get; private set; }
        public CollisionLayer CollisionLayer => CollisionLayer.Meteor;

        public override void Initialize()
        {
            MovementSpeed = _meteorStrategy.MovementSpeed;
            CollisionDamageAmount = _meteorStrategy.CollisionDamage;

            _physicsComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
            _healthComponent.Initialize(this);
            _healthComponent.Died += MeteorOnDied;
        }

        public override void Update(IGameTime gameTime)
        {
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
            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.MeteorConstants.Audio.HitSoundEffectName));

            switch (gameObject)
            {
                case Player.Player player:
                    Damage(player.CollisionDamageAmount);
                    break;
                case Bullet bullet:
                    Damage(bullet.CollisionDamageAmount);
                    break;
                case HealthPack healthPack:
                    break;
                case Meteor meteor:
                    //ToDo do something here to stop meteors overlapping
                    break;
                case Enemy enemy:
                    //Damage(enemy.CollisionDamageAmount);
                    break;
            }
            Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
        }

        private void MeteorOnDied(object sender, EventArgs e)
        {
            //Meteor destroyed
            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(_meteorStrategy.DestroyedSoundEffect));
            
            _gameContext.NotificationMediator.PublishPlayerScoreChange(new PlayerScoreNotificationArguments(_meteorStrategy.ScoreValue));
            _gameContext.NotificationMediator.PublishMeteorDestroyed(new MeteorDestroyedNotificationArguments(_meteorStrategy.MeteorType, Position));
            _healthComponent.Died -= MeteorOnDied;
            IsActive = false;
        }
    }
}