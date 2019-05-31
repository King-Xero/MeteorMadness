using System;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthComponent : IHealthComponent
    {
        private readonly int _initialMaxHealth;
        private readonly IHealthContainer _playerHealthContainer;

        public PlayerHealthComponent(int initialMaxHealth, IHealthContainer playerHealthContainer)
        {
            _initialMaxHealth = initialMaxHealth;
            _playerHealthContainer = playerHealthContainer ?? throw new ArgumentNullException(nameof(playerHealthContainer));
        }

        public void Initialize(IHandleHealth player)
        {
            player.MaxHealth = GameConstants.Player.InitialMaxHealth;

            player.Healed += PlayerOnHealed;
            player.Damaged += PlayerOnDamaged;
            player.Died += PlayerOnDied;
        }

        public void Update(IHandleHealth player)
        {
            throw new NotImplementedException();
        }

        public void Draw(IHandleHealth player)
        {
            throw new NotImplementedException();
        }

        private void PlayerOnHealed(object sender, HealEventArgs e)
        {
            _playerHealthContainer.Replenish(e.Amount);
        }

        private void PlayerOnDamaged(object sender, DamageEventArgs e)
        {
            _playerHealthContainer.Deplete(e.Amount);
        }

        private void PlayerOnDied(object sender, EventArgs e)
        {
            //Player is dead
        }
    }
}