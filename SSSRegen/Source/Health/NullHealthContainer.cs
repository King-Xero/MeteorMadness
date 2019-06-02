namespace SSSRegen.Source.Health
{
    public class NullHealthContainer : IHealthContainer
    {
        public NullHealthContainer()
        {
        }

        public void Update()
        {
            //Do nothing
        }

        public void Draw()
        {
            //Do nothing
        }

        public void Replenish(int numberOfHealthPieces)
        {
            //Do nothing
        }

        public void Deplete(int numberOfHealthPieces)
        {
            //Do nothing
        }
    }
}