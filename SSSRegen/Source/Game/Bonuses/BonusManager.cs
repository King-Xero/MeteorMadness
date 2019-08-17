using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Meteors;
using SSSRegen.Source.Game.Notifications;

namespace SSSRegen.Source.Game.Bonuses
{
    public class BonusManager : IGameObjectManager, IReceiveNotifications<MeteorDestroyedNotificationArguments>, IDisposable
    {
        private readonly GameContext _gameContext;
        private readonly IBonusFactory _bonusFactory;
        private readonly ICollisionSystem _collisionSystem;

        private List<IHandleCollisions> _bonuses;
        private List<IHandleCollisions> _bonusesToAdd;
        private bool _isPaused;
        private IDisposable _meteorDestroyedHandler;

        public BonusManager(GameContext gameContext, IBonusFactory bonusFactory, ICollisionSystem collisionSystem)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _bonusFactory = bonusFactory ?? throw new ArgumentNullException(nameof(bonusFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _meteorDestroyedHandler = _gameContext.NotificationMediator.SubscribeToMeteorDestroyedNotifications(this);

            _bonuses = new List<IHandleCollisions>();
            _bonusesToAdd = new List<IHandleCollisions>();
            
            for (int i = 0; i < GameConstants.BonusConstants.HealthPackConstants.InitialCount; i++)
            {
                var healthPack = _bonusFactory.CreateHealthPack();
                healthPack.Initialize();
                _collisionSystem.RegisterEntity(healthPack);
                _bonuses.Add(healthPack);
            }
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

            foreach (var bonus in _bonuses)
            {
                if (bonus.IsActive)
                {
                    bonus.Update(gameTime);
                }
            }

            _bonuses.AddRange(_bonusesToAdd);
            _bonusesToAdd.Clear();
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var bonus in _bonuses)
            {
                if (bonus.IsActive)
                {
                    bonus.Draw(gameTime);
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = true;
        }

        public Task OnNotificationReceived(MeteorDestroyedNotificationArguments args)
        {
            if (args.MeteorType == MeteorType.Tiny)
            {
                //Potentially spawn a bonus
                if (_gameContext.Random.Next(1, 101) <= GameConstants.BonusConstants.HealthPackConstants.SpawnPercentageChance)
                {
                    var healthPack = SpawnBonus(_bonusFactory.CreateHealthPack);
                    healthPack.Position = args.Position;
                }
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //ToDo dispose handler in unload/clean up method
            _meteorDestroyedHandler?.Dispose();
        }

        private IHandleCollisions SpawnBonus(Func<HealthPack> createBonus)
        {
            var bonusToSpawn = _bonuses.FirstOrDefault(b => !b.IsActive);
            if (bonusToSpawn == null)
            {
                bonusToSpawn = createBonus();
                _collisionSystem.RegisterEntity(bonusToSpawn);

                _bonusesToAdd.Add(bonusToSpawn);
            }

            bonusToSpawn.Initialize();

            bonusToSpawn.IsActive = true;
            return bonusToSpawn;
        }
    }
}