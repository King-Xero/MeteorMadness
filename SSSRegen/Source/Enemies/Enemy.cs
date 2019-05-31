using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.Health;

namespace SSSRegen.Source.Enemies
{
    public class Enemy : GameObject, IHandleHealth
    {
        private readonly IHealthComponent _healthComponent;

        public Enemy(IHealthComponent healthComponent, IInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
        }

        public int CurrentHealth { get; private set; }
        //MaxHealth set in HealthComponent
        public int MaxHealth { get; set; }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;
        public event EventHandler<EventArgs> Died;

        public override void Initialize()
        {
            _healthComponent.Initialize(this);
            base.Initialize();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
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
    }
}