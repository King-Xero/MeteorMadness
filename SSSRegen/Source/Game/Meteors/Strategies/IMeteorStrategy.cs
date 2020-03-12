namespace SSSRegen.Source.Game.Meteors.Strategies
{
    public interface IMeteorStrategy
    {
        MeteorType MeteorType { get; }
        int CollisionDamage { get; }
        int ScoreValue { get; }
        int MovementSpeed { get; }
        string DestroyedSoundEffect { get; }
    }
}