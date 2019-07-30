namespace SSSRegen.Source.Game.Health
{
    public interface IHealthUnit 
    {
        int FilledHealthPieces { get; }
        int EmptyHealthPieces { get; }

        void Initialize();
        void Update();
        void Draw();
        void Replenish(int numberOfHealthPieces);
        void Deplete(int numberOfHealthPieces);
    }
}