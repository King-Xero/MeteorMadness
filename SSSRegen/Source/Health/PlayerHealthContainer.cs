using System;
using System.Collections.Generic;
using System.Linq;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthContainer : IHealthContainer
    {
        private readonly GameContext _gameContext;
        private IHealthUnit[] _healthUnits;

        public PlayerHealthContainer(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            //ToDo pass in health unit creation strategy
            //Create units in initialize method, based on max health property.
            //Use update method to check max health, and add new health units if max health has increased
        }

        public void Initialize(IHandleHealth entity)
        {
            var healthUnits = new List<IHealthUnit>();

            for (int i = 0; i < entity.MaxHealth / PlayerHealthUnit.HEALTH_PIECES_PER_UNIT; i++)
            {
                //ToDo use creation strategy
                var healthUnit = new PlayerHealthUnit(_gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.RedTextureName));
                healthUnit.Initialize();

                healthUnits.Add(healthUnit);
            }

            _healthUnits = healthUnits.ToArray();
        }

        public void Update(IHandleHealth entity)
        {
            foreach (var healthUnit in _healthUnits)
            {
                healthUnit.Update();
            }
        }

        public void Draw()
        {
            foreach (var healthUnit in _healthUnits)
            {
                healthUnit.Draw();
            }
        }

        public void Replenish(int numberOfHealthPieces)
        {
            foreach (var healthUnit in _healthUnits)
            {
                var toReplenish = numberOfHealthPieces < healthUnit.EmptyHealthPieces
                    ? numberOfHealthPieces
                    : healthUnit.EmptyHealthPieces;

                numberOfHealthPieces -= healthUnit.EmptyHealthPieces;
                healthUnit.Replenish(toReplenish);
                if (numberOfHealthPieces <= 0) break;
            }
        }

        public void Deplete(int numberOfHealthPieces)
        {
            foreach (var healthUnit in _healthUnits.Reverse())
            {
                var toDeplete = numberOfHealthPieces < healthUnit.FilledHealthPieces
                    ? numberOfHealthPieces
                    : healthUnit.FilledHealthPieces;

                numberOfHealthPieces -= healthUnit.FilledHealthPieces;
                healthUnit.Deplete(toDeplete);
                if (numberOfHealthPieces <= 0) break;
            }
        }
    }
}