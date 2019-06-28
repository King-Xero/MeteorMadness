using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.Menus;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Player;
using SSSRegen.Source.Projectiles;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface IGameFactories
    {
        IMenuFactory MenuFactory { get; }
        IEnemyFactory EnemyFactory { get; }
        IMeteorFactory MeteorsFactory { get; }
        IBonusFactory BonusesFactory { get; }
        IPlayerFactory PlayerFactory { get; }
        IProjectileFactory ProjectileFactory { get; }
    }
}