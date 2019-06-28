using System;
using SSSRegen.Source.Bonuses;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Enemies;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;
using SSSRegen.Source.Meteors;
using SSSRegen.Source.Player;
using SSSRegen.Source.Projectiles;

namespace SSSRegen.Source.Core
{
    public class GameFactories : IGameFactories
    {
        public GameFactories(GameContext gameContext, Random random)
        {
            MenuFactory = new MenuFactory(gameContext);
            ProjectileFactory = new ProjectileFactory(gameContext, random);
            EnemyFactory = new EnemyFactory(gameContext, random);
            MeteorsFactory = new MeteorFactory(gameContext, random);
            BonusesFactory = new BonusFactory(gameContext, random);
            PlayerFactory = new PlayerFactory(gameContext);
        }

        public IMenuFactory MenuFactory { get; }
        public IEnemyFactory EnemyFactory { get; }
        public IMeteorFactory MeteorsFactory { get; }
        public IBonusFactory BonusesFactory { get; }
        public IPlayerFactory PlayerFactory { get; set; }
        public IProjectileFactory ProjectileFactory { get; set; }
    }
}