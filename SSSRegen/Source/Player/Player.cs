using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.Health;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public class Player : GameObject, IHandleHealth, IHandleScore
    {
        private readonly IHealthComponent _healthComponent;
        private readonly IScoreComponent _scoreComponent;
        public Player(IHealthComponent healthComponent, IScoreComponent scoreComponent, IInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _scoreComponent = scoreComponent ?? throw new ArgumentNullException(nameof(scoreComponent));
        }

        public int CurrentHealth { get; private set; }
        //MaxHealth set in HealthComponent
        public int MaxHealth { get; set; }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;
        public event EventHandler<EventArgs> Died;
        public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated = delegate { };

        public void UpdateScore(int scoreAmount)
        {
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(scoreAmount));
        }

        public override void Initialize()
        {
            _healthComponent.Initialize(this);
            _scoreComponent.Initialize(this);
            base.Initialize();

            Reset();
        }

        public override void Update()
        {
            _healthComponent.Update(this);
            _scoreComponent.Update(this);
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            _healthComponent.Draw(this);
            _scoreComponent.Draw(this);
            base.Draw(gameTime);
        }

        public void Heal(int healAmount)
        {
            var newHealth = Math.Min(CurrentHealth + healAmount, MaxHealth);
            Healed?.Invoke(this, new HealEventArgs(newHealth - CurrentHealth));
            CurrentHealth = newHealth;
        }

        public void Damage(int damageAmount)
        {
            var newHealth = Math.Max(CurrentHealth - damageAmount, 0);
            Damaged?.Invoke(this, new DamageEventArgs(CurrentHealth - newHealth));
            CurrentHealth = newHealth;
            if (CurrentHealth <= 0)
            {
                Died?.Invoke(this, EventArgs.Empty);
            }
        }

        private void Reset()
        {
            CurrentHealth = MaxHealth;

            //Put in start position
            //Initialize health
            //Initialize score

            //if (_playerIndex == PlayerIndex.One)
            //{
            //    _position.X = _screenBounds.Width / 3; //Player ones's _position along the bottom of the screen
            //}
            //else
            //{
            //    _position.X = (int)(_screenBounds.Width / 1.5); //Player two's _position along the bottom of the screen
            //}

            //_position.Y = _screenBounds.Height - _sprite.Bounds.Height - 10; //Places the player(s) at the very bottom of the screen
            //_score = 0; //Resets the score to zero
            //_health = INITIAL_HEALTH; //Resets the health to intial value

            //IsEnabled = true;
        }
    }
}