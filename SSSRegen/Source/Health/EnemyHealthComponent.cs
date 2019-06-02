using System;

namespace SSSRegen.Source.Health
{
    public class EnemyHealthComponent : IHealthComponent
    {
        private readonly int _initialMaxHealth;
        private readonly IHealthContainer _enemyHealthContainer;

        private int _currentHealth;
        private int _maxHealth;

        public EnemyHealthComponent(int initialMaxHealth, IHealthContainer enemyHealthContainer)
        {
            _initialMaxHealth = initialMaxHealth;
            _enemyHealthContainer = enemyHealthContainer ?? throw new ArgumentNullException(nameof(enemyHealthContainer));
        }

        public event EventHandler<EventArgs> Died = delegate { };

        public void Initialize(IHandleHealth enemy)
        {
            _maxHealth = _initialMaxHealth;
            _currentHealth = _maxHealth;

            enemy.Healed += EnemyOnHealed;
            enemy.Damaged += EnemyOnDamaged;
        }

        public void Update(IHandleHealth enemy)
        {
            _enemyHealthContainer.Update();
        }

        public void Draw(IHandleHealth enemy)
        {
            _enemyHealthContainer.Draw();
        }

        private void EnemyOnHealed(object sender, HealEventArgs e)
        {
            var newHealth = Math.Min(_currentHealth + e.Amount, _maxHealth);
            _enemyHealthContainer.Replenish(newHealth - _currentHealth);
            _currentHealth = newHealth;
        }

        private void EnemyOnDamaged(object sender, DamageEventArgs e)
        {
            var newHealth = Math.Max(_currentHealth - e.Amount, 0);
            _enemyHealthContainer.Deplete(_currentHealth - newHealth);

            if (_currentHealth <= 0)
            {
                Died?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}