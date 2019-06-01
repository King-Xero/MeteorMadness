namespace SSSRegen.Source.Score
{
    public interface IScoreComponent
    {
        void Initialize(IHandleScore player);
        void Update(IHandleScore player);
        void Draw(IHandleScore player);
    }
}