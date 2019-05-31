namespace SSSRegen.Source.Health
{
    public interface IHealthComponent
    {
        void Initialize(IHandleHealth player);
        void Update(IHandleHealth player);
        void Draw(IHandleHealth player);
    }
}