namespace SSSRegen.Source.Health
{
    public class NullHealthContainer : IHealthContainer
    {
        public NullHealthContainer()
        {
        }

        public void Initialize(IHandleHealth entity)
        {
            //Do nothing
        }

        public void Update(IHandleHealth entity)
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