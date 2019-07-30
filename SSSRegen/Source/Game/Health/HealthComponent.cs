using System;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Game.Health
{
    public class HealthComponent : IHealthComponent
    {
        private readonly int _initialMaxHealth;
        private readonly IHealthContainer _healthContainer;

        private int _currentHealth;
        private int _maxHealth;

        public HealthComponent(int initialMaxHealth, IHealthContainer healthContainer)
        {
            _initialMaxHealth = initialMaxHealth;
            _healthContainer = healthContainer ?? throw new ArgumentNullException(nameof(healthContainer));
        }

        public event EventHandler<EventArgs> Died = delegate { };

        public void Initialize(IHandleHealth entity)
        {
            _maxHealth = entity.MaxHealth;
            _currentHealth = _maxHealth;

            _healthContainer.Initialize(entity);

            entity.Healed += OnHealed;
            entity.Damaged += OnDamaged;
        }

        public void Update(IHandleHealth entity, IGameTime gameTime)
        {
            _healthContainer.Update(entity);
        }

        public void Draw(IHandleHealth entity, IGameTime gameTime)
        {
            _healthContainer.Draw();
        }

        private void OnHealed(object sender, HealEventArgs e)
        {
            var newHealth = Math.Min(_currentHealth + e.Amount, _maxHealth);
            _healthContainer.Replenish(newHealth - _currentHealth);
            _currentHealth = newHealth;
        }

        private void OnDamaged(object sender, DamageEventArgs e)
        {
            var newHealth = Math.Max(_currentHealth - e.Amount, 0);
            _healthContainer.Deplete(_currentHealth - newHealth);
            _currentHealth = newHealth;

            if (_currentHealth <= 0)
            {
                Died?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}