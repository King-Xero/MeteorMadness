using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Notifications;

namespace SSSRegen.Source.Game.Meteors
{
    public class MeteorsManager : IGameObjectManager, IReceiveNotifications<MeteorDestroyedNotificationArguments>, IDisposable
    {
        private readonly GameContext _gameContext;
        private readonly IMeteorFactory _meteorFactory;
        private readonly ICollisionSystem _collisionSystem;

        private Dictionary<string, List<Meteor>> _meteors;
        private Dictionary<string, List<Meteor>> _meteorsToAdd;
        private List<PausableTimer> _spawnTimers;
        private bool _isPaused;
        private IDisposable _meteorDestroyedHandler;

        public MeteorsManager(GameContext gameContext, IMeteorFactory meteorFactory, ICollisionSystem collisionSystem)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _meteorFactory = meteorFactory ?? throw new ArgumentNullException(nameof(meteorFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _meteorDestroyedHandler = _gameContext.NotificationMediator.SubscribeToMeteorDestroyedNotifications(this);

            _meteors = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.MeteorConstants.BigMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.MediumMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.SmallMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.TinyMeteor1Constants.Name, new List<Meteor>()},
            };

            _meteorsToAdd = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.MeteorConstants.BigMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.MediumMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.SmallMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.TinyMeteor1Constants.Name, new List<Meteor>()},
            };

            _spawnTimers = new List<PausableTimer>();

            for (var i = 0; i < GameConstants.MeteorConstants.BigMeteor1Constants.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateBigMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.MeteorConstants.BigMeteor1Constants.Name].Add(meteor);
            }

            AddSpawnTimer(15000, _meteorFactory.CreateBigMeteor, GameConstants.MeteorConstants.BigMeteor1Constants.Name);

            for (var i = 0; i < GameConstants.MeteorConstants.MediumMeteor1Constants.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateMediumMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.MeteorConstants.MediumMeteor1Constants.Name].Add(meteor);
            }

            AddSpawnTimer(15000, _meteorFactory.CreateMediumMeteor, GameConstants.MeteorConstants.MediumMeteor1Constants.Name);

            for (var i = 0; i < GameConstants.MeteorConstants.SmallMeteor1Constants.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateSmallMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.MeteorConstants.SmallMeteor1Constants.Name].Add(meteor);
            }

            AddSpawnTimer(5000, _meteorFactory.CreateSmallMeteor, GameConstants.MeteorConstants.SmallMeteor1Constants.Name);

            for (var i = 0; i < GameConstants.MeteorConstants.TinyMeteor1Constants.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateTinyMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.MeteorConstants.TinyMeteor1Constants.Name].Add(meteor);
            }

            AddSpawnTimer(5000, _meteorFactory.CreateTinyMeteor, GameConstants.MeteorConstants.TinyMeteor1Constants.Name);

            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Start();
            }
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    if (meteor.IsActive)
                    {
                        meteor.Update(gameTime);
                    }
                }
            }

            foreach (var meteorType in _meteorsToAdd)
            {
                _meteors[meteorType.Key].AddRange(meteorType.Value);
                meteorType.Value.Clear();
            }
        }

        public void Draw(IGameTime gameTime)
        {
            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    if (meteor.IsActive)
                    {
                        meteor.Draw(gameTime);
                    }
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Pause();
            }
        }

        public void Resume()
        {
            _isPaused = false;
            foreach (var spawnTimer in _spawnTimers)
            {
                spawnTimer.Resume();
            }
        }

        public Task OnNotificationReceived(MeteorDestroyedNotificationArguments args)
        {
            switch (args.MeteorType)
            {
                case MeteorType.Tiny:
                    //ToDo Potentially spawn a power-up
                    break;
                case MeteorType.Small:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateTinyMeteor, GameConstants.MeteorConstants.TinyMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                case MeteorType.Medium:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateSmallMeteor, GameConstants.MeteorConstants.SmallMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                case MeteorType.Big:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateMediumMeteor, GameConstants.MeteorConstants.MediumMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //ToDo Spawn particles
            
            return Task.FromResult<object>(null);
            //ToDo upgrade net framework
            //return Task.CompletedTask;
        }

        public void Dispose()
        {
            //ToDo dispose handler in unload/clean up method
            _meteorDestroyedHandler?.Dispose();
        }

        private void AddSpawnTimer(int interval, Func<Meteor> createMeteor, string enemyName)
        {
            var timer = new PausableTimer(interval);
            timer.Elapsed += (sender, args) => SpawnMeteor(createMeteor, enemyName);
            _spawnTimers.Add(timer);
        }

        private Meteor SpawnMeteor(Func<Meteor> createMeteor, string meteorName)
        {
            var meteorToSpawn = _meteors[meteorName].FirstOrDefault(b => !b.IsActive);
            if (meteorToSpawn == null)
            {
                meteorToSpawn = createMeteor();
                _collisionSystem.RegisterEntity(meteorToSpawn);

                _meteorsToAdd[meteorName].Add(meteorToSpawn);
            }
            meteorToSpawn.Initialize();
            meteorToSpawn.IsActive = true;
            return meteorToSpawn;
        }
    }
}