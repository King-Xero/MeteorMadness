using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Bonuses
{
    public class BonusManager : IGameObjectManager
    {
        private readonly IBonusFactory _bonusFactory;
        private readonly ICollisionSystem _collisionSystem;
        private List<HealthPack> _healthPacks;

        public BonusManager(IBonusFactory bonusFactory, ICollisionSystem collisionSystem)
        {
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _healthPacks = new List<HealthPack>();
            for (int i = 0; i < GameConstants.Bonuses.HealthPack.InitialCount; i++)
            {
                _healthPacks.Add(_bonusFactory.CreateHealthPack());
            }

            foreach (var healthPack in _healthPacks)
            {
                healthPack.Initialize();
                _collisionSystem.RegisterEntity(healthPack);
            }
        }

        public void Update(IGameTime gameTime)
        {
            foreach (var healthPack in _healthPacks)
            {
                healthPack.Update(gameTime);
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var healthPack in _healthPacks)
            {
                healthPack.Draw(gameTime);
            }
        }
    }
}