namespace SSSRegen.Source.Health
{
    public interface IHealthContainer
    {
        void Update();
        void Draw();
        void Replenish(int amount);
        void Deplete(int amount);
    }
}