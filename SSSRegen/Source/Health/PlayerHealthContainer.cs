using System.Linq;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthContainer : IHealthContainer
    {
        private readonly IHealthUnit[] _healthUnits;

        public PlayerHealthContainer(IHealthUnit[] healthUnits)
        {
            _healthUnits = healthUnits;
        }

        public void Update()
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