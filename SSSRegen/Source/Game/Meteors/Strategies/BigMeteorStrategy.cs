using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.Meteors.Strategies
{
    public class BigMeteorStrategy : IMeteorStrategy
    {
        public MeteorType MeteorType => MeteorType.Big;
        public int CollisionDamage => GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.CollisionDamage;
        public int ScoreValue => GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.ScoreValue;
        public int MovementSpeed => GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.MovementSpeed;
        public string DestroyedSoundEffect => GameConstants.MeteorConstants.BigMeteorConstants.Audio.DestroyedSoundEffectName;
    }
}