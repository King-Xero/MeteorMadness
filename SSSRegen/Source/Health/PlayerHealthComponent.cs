using System;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthComponent : IHealthComponent
    {
        private readonly int _initialMaxHealth;
        private readonly IHealthContainer _playerHealthContainer;

        private int _currentHealth;
        private int _maxHealth;

        public PlayerHealthComponent(int initialMaxHealth, IHealthContainer playerHealthContainer)
        {
            _initialMaxHealth = initialMaxHealth;
            _playerHealthContainer = playerHealthContainer ?? throw new ArgumentNullException(nameof(playerHealthContainer));
        }

        public event EventHandler<EventArgs> Died = delegate { };

        public void Initialize(IHandleHealth player)
        {
            _maxHealth = GameConstants.Player.InitialMaxHealth;
            _currentHealth = _maxHealth;

            player.Healed += PlayerOnHealed;
            player.Damaged += PlayerOnDamaged;
        }

        public void Update(IHandleHealth player)
        {
            _playerHealthContainer.Update();
        }

        public void Draw(IHandleHealth player)
        {
            _playerHealthContainer.Draw();
        }

        private void PlayerOnHealed(object sender, HealEventArgs e)
        {
            var newHealth = Math.Min(_currentHealth + e.Amount, _maxHealth);
            _playerHealthContainer.Replenish(newHealth - _currentHealth);
            _currentHealth = newHealth;
        }

        private void PlayerOnDamaged(object sender, DamageEventArgs e)
        {
            var newHealth = Math.Max(_currentHealth - e.Amount, 0);
            _playerHealthContainer.Deplete(_currentHealth - newHealth);

            if (_currentHealth <= 0)
            {
                Died?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}