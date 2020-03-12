using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.Entities;
using SSSRegen.Source.Core.Interfaces.Audio;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.Bonuses;
using SSSRegen.Source.Game.Enemies;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Meteors;
using SSSRegen.Source.Game.Notifications;
using SSSRegen.Source.Game.Projectiles;
using SSSRegen.Source.Game.Score;

namespace SSSRegen.Source.Game.Player
{
    public class Player : GameObject, IPlayer
    {
        private readonly GameContext _gameContext;
        private readonly IComponent<IPlayer> _inputComponent;
        private readonly IHealthComponent _healthComponent;
        private readonly IPlayerPhysicsComponent _physicsComponent;
        private readonly IDrawableComponent<IPlayer> _graphicsComponent;
        private readonly IProjectilesManager _projectileManager;
        private readonly ISoundEffect _acceleratingSoundEffect;
        private readonly ISoundEffect _invulnerabilitySoundEffect;
        private readonly Stopwatch _invulnerableStopwatch;
        private readonly Stopwatch _flashingStopwatch;

        private bool _isAccelerating;
        private bool _isVisible;

        public Player(GameContext gameContext, IHealthComponent healthComponent, IComponent<IPlayer> inputComponent, IPlayerPhysicsComponent physicsComponent, IDrawableComponent<IPlayer> graphicsComponent, IProjectilesManager projectileManager)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _inputComponent = inputComponent ?? throw new ArgumentNullException(nameof(inputComponent));
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            _graphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));
            _projectileManager = projectileManager ?? throw new ArgumentNullException(nameof(projectileManager));

            _acceleratingSoundEffect = _gameContext.GameAudio.CreateSoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.ThrusterConstants.Thruster1Constants.Audio.ThrustingSoundEffectName));
            _invulnerabilitySoundEffect = _gameContext.GameAudio.CreateSoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.PlayerConstants.Audio.InvulnerableSoundEffectName));

            _invulnerableStopwatch = new Stopwatch();
            _flashingStopwatch = new Stopwatch();
        }

        public event EventHandler<HealEventArgs> Healed = delegate { };
        public event EventHandler<DamageEventArgs> Damaged = delegate { };

        public float CurrentHealth => _healthComponent.CurrentHealth;
        public float MaxHealth => _healthComponent.MaxHealth;
        public Vector2 ThrustingVelocity => _physicsComponent.ThrustingVelocity;

        public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated = delegate { };

        public bool IsAccelerating
        {
            get => _isAccelerating;
            set
            {
                if (_isAccelerating == value) return;
                _isAccelerating = value;
                if (_isAccelerating)
                {
                    PlayAcceleratingSoundEffect();
                }
                else
                {
                    StopAcceleratingSoundEffect();
                }
            }
        }

        public bool CanCollide { get; set; }

        public float RotationSpeed { get; set; }
        public int CollisionDamageAmount { get; private set; }

        public CollisionLayer CollisionLayer => CollisionLayer.Player;

        public override void Initialize()
        {
            CollisionDamageAmount = GameConstants.PlayerConstants.InitialCollisionDamage;
            IsActive = true;

            CanCollide = true;
            _isVisible = true;

            _inputComponent.Initialize(this);
            _graphicsComponent.Initialize(this);
            _physicsComponent.Initialize(this);
            _healthComponent.Initialize(this);
            _healthComponent.Died += PlayerOnDied;

            _projectileManager.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            if (!CanCollide)
            {
                if (_flashingStopwatch.Elapsed > TimeSpan.FromSeconds(GameConstants.PlayerConstants.InvulnerabilityFlashDelay))
                {
                    _flashingStopwatch.Restart();
                    
                    //"Flashes" graphics for invulnerability
                    _isVisible = !_isVisible;
                }

                if (_invulnerableStopwatch.Elapsed > TimeSpan.FromSeconds(GameConstants.PlayerConstants.InvulnerabilityDuration))
                {
                    StopInvulnerability();
                }
            }

            if (IsActive)
            {
                _inputComponent.Update(this, gameTime);
                _graphicsComponent.Update(this, gameTime);
                _physicsComponent.Update(this, gameTime);
                _projectileManager.Update(gameTime);
            }
            _healthComponent.Update(this, gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _projectileManager.Draw(gameTime);
            if (IsActive && _isVisible)
            {
                _graphicsComponent.Draw(this, gameTime);
            }
            _healthComponent.Draw(this, gameTime);
        }

        public void Heal(int healAmount)
        {
            Healed?.Invoke(this, new HealEventArgs(healAmount));
            UpdatePlayerDamageLevel();
        }

        public void Damage(int damageAmount)
        {
            Damaged?.Invoke(this, new DamageEventArgs(damageAmount));
            UpdatePlayerDamageLevel();
        }

        public void UpdateScore(int scoreAmount)
        {
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(scoreAmount));
        }

        public void CollidedWith(IHandleCollisions gameObject)
        {
            if (CanCollide)
            {
                switch (gameObject)
                {
                    case Player player:
                        break;
                    case Bullet bullet:
                        //ToDo Add enemy bullet
                        break;
                    case HealthPack healthPack:
                        Heal(healthPack.HealAmount);
                        break;
                    case Enemy enemy:
                        StartInvulnerability();
                        _gameContext.GameAudio.PlaySoundEffect(
                            _gameContext.AssetManager.GetSoundEffect(GameConstants.PlayerConstants.Audio
                                .HitSoundEffectName));
                        Damage(enemy.CollisionDamageAmount);
                        break;
                    case Meteor meteor:
                        StartInvulnerability();
                        _gameContext.GameAudio.PlaySoundEffect(
                            _gameContext.AssetManager.GetSoundEffect(GameConstants.PlayerConstants.Audio
                                .HitSoundEffectName));
                        Damage(meteor.CollisionDamageAmount);
                        break;
                }

                Console.WriteLine($"{GetType()} collided with {gameObject.GetType()}");
            }
        }

        public void Shoot()
        {
            Console.WriteLine("Pew!!!");
            _projectileManager.Shoot(this);
        }

        private void PlayerOnDied(object sender, EventArgs e)
        {
            //Stop sound effects in case they are currently playing
            StopAcceleratingSoundEffect();
            StopInvulnerabilitySoundEffect();

            _gameContext.GameAudio.PlaySoundEffect(_gameContext.AssetManager.GetSoundEffect(GameConstants.PlayerConstants.Audio.DestroyedSoundEffectName));
            _healthComponent.Died -= PlayerOnDied;

            // Hide and disable the player
            IsActive = false;

            _gameContext.NotificationMediator.PublishPlayerDied(new PlayerDiedNotification());
        }

        private void PlayAcceleratingSoundEffect()
        {
            _acceleratingSoundEffect.Play(true);
        }

        private void StopAcceleratingSoundEffect()
        {
            _acceleratingSoundEffect.Stop();
        }

        private void PlayInvulnerabilitySoundEffect()
        {
            _invulnerabilitySoundEffect.Play(true);
        }

        private void StopInvulnerabilitySoundEffect()
        {
            _invulnerabilitySoundEffect.Stop();
        }

        private void UpdatePlayerDamageLevel()
        {
            if (CurrentHealth <= (MaxHealth / 100) * GameConstants.PlayerConstants.HeavyDamageThreshold)
            {
                _gameContext.NotificationMediator.PublishPlayerDamageLevel(PlayerDamageLevel.Heavy);
            }
            else if (CurrentHealth <= (MaxHealth / 100) * GameConstants.PlayerConstants.MediumDamageThreshold)
            {
                _gameContext.NotificationMediator.PublishPlayerDamageLevel(PlayerDamageLevel.Medium);
            }
            else if (CurrentHealth <= (MaxHealth / 100) * GameConstants.PlayerConstants.LightDamageThreshold)
            {
                _gameContext.NotificationMediator.PublishPlayerDamageLevel(PlayerDamageLevel.Light);
            }
            else if (CurrentHealth.ToInt() == MaxHealth.ToInt())
            {
                _gameContext.NotificationMediator.PublishPlayerDamageLevel(PlayerDamageLevel.None);
            }
        }
        
        private void StartInvulnerability()
        {
            CanCollide = false;
            
            _invulnerableStopwatch.Start();
            _flashingStopwatch.Start();

            PlayInvulnerabilitySoundEffect();
        }

        private void StopInvulnerability()
        {
            CanCollide = true;
            _isVisible = true;

            _invulnerableStopwatch.Reset();
            _flashingStopwatch.Reset();

            StopInvulnerabilitySoundEffect();
        }
    }
}