using System;

namespace SSSRegen.Source.Health
{
    public class EnemyHealthComponent : IHealthComponent
    {
        private readonly int _initialMaxHealth;
        private readonly IHealthContainer _enemyHealthContainer;

        public EnemyHealthComponent(int initialMaxHealth, IHealthContainer enemyHealthContainer)
        {
            _initialMaxHealth = initialMaxHealth;
            _enemyHealthContainer = enemyHealthContainer ?? throw new ArgumentNullException(nameof(enemyHealthContainer));
        }

        public void Initialize(IHandleHealth enemy)
        {
            enemy.MaxHealth = _initialMaxHealth;

            enemy.Healed += EnemyOnHealed;
            enemy.Damaged += EnemyOnDamaged;
            enemy.Died += EnemyOnDied;
        }

        public void Update(IHandleHealth enemy)
        {
            throw new NotImplementedException();
        }

        public void Draw(IHandleHealth enemy)
        {
            throw new NotImplementedException();
        }

        private void EnemyOnHealed(object sender, HealEventArgs e)
        {
            _enemyHealthContainer.Replenish(e.Amount);
        }

        private void EnemyOnDamaged(object sender, DamageEventArgs e)
        {
            _enemyHealthContainer.Deplete(e.Amount);
        }

        private void EnemyOnDied(object sender, EventArgs e)
        {
            //Enemy is dead
        }
    }
}