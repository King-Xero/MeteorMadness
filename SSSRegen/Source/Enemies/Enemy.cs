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

        public Enemy(IHealthComponent healthComponent, IGameObjectInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
        }

        public event EventHandler<HealEventArgs> Healed;
        public event EventHandler<DamageEventArgs> Damaged;

        public override void Initialize()
        {
            _healthComponent.Initialize(this);
            _healthComponent.Died += EnemyOnDied;

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