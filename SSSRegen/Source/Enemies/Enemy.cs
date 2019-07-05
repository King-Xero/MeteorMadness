using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.Health;

namespace SSSRegen.Source.Enemies
{
    public class Enemy : GameObject, IHandleHealth
    {
        private readonly IHealthComponent _healthComponent;

        public Enemy(int maxHealth, IHealthComponent healthComponent, IComponent<IGameObject> inputComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            MaxHealth = maxHealth;
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
        }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public int MaxHealth { get; private set; }

        public override void Initialize()
        {
            _healthComponent.Initialize(this);
            _healthComponent.Died += EnemyOnDied;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _healthComponent.Update(this);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
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

        private void EnemyOnDied(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Enemy died
        }
    }
}