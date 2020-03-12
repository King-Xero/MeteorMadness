using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Meteors.Strategies
{
    public class SmallMeteorStrategy : IMeteorStrategy
    {
        public MeteorType MeteorType => MeteorType.Small;
        public int CollisionDamage => GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.CollisionDamage;
        public int ScoreValue => GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.ScoreValue;
        public int MovementSpeed => GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.MovementSpeed;
        public string DestroyedSoundEffect => GameConstants.MeteorConstants.SmallMeteorConstants.Audio.DestroyedSoundEffectName;
    }
}