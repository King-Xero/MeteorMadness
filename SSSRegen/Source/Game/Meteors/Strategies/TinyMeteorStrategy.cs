using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Meteors.Strategies
{
    public class TinyMeteorStrategy : IMeteorStrategy
    {
        public MeteorType MeteorType => MeteorType.Tiny;
        public int CollisionDamage => GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.CollisionDamage;
        public int ScoreValue => GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.ScoreValue;
        public int MovementSpeed => GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.MovementSpeed;
        public string DestroyedSoundEffect => GameConstants.MeteorConstants.TinyMeteorConstants.Audio.DestroyedSoundEffectName;
    }
}