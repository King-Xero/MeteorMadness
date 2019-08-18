using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Meteors.Strategies
{
    public class MediumMeteorStrategy : IMeteorStrategy
    {
        public MeteorType MeteorType => MeteorType.Medium;
        public int CollisionDamage => GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.CollisionDamage;
        public int ScoreValue => GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.ScoreValue;
        public int MovementSpeed => GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.MovementSpeed;
        public string DestroyedSoundEffect => GameConstants.MeteorConstants.MediumMeteorConstants.Audio.DestroyedSoundEffectName;
    }
}