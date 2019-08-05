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
    public class MeteorsManager : IGameObjectManager, IReceiveNotifications<MeteorDestroyedNotificationArguments>
    {
        private readonly IMeteorFactory _meteorFactory;
        private readonly ICollisionSystem _collisionSystem;

        private Dictionary<string, List<Meteor>> _meteors;
        private List<PausableTimer> _spawnTimers;
        private bool _isPaused;

        public MeteorsManager(IMeteorFactory meteorFactory, ICollisionSystem collisionSystem)
        {
            _meteorFactory = meteorFactory ?? throw new ArgumentNullException(nameof(meteorFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
        }

        public void Initialize()
        {
            _meteors = new Dictionary<string, List<Meteor>>
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
                    SpawnMeteor(_meteorFactory.CreateTinyMeteor, GameConstants.MeteorConstants.TinyMeteor1Constants.Name);
                    break;
                case MeteorType.Medium:
                    SpawnMeteor(_meteorFactory.CreateSmallMeteor, GameConstants.MeteorConstants.SmallMeteor1Constants.Name);
                    break;
                case MeteorType.Big:
                    SpawnMeteor(_meteorFactory.CreateMediumMeteor, GameConstants.MeteorConstants.MediumMeteor1Constants.Name);
                    //ToDo set meteor position
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //ToDo Spawn particles
            
            return Task.FromResult<object>(null);
            //ToDo upgrade net framework
            //return Task.CompletedTask;
        }

        private void AddSpawnTimer(int interval, Func<Meteor> createMeteor, string enemyName)
        {
            var timer = new PausableTimer(interval);
            timer.Elapsed += (sender, args) => SpawnMeteor(createMeteor, enemyName);
            _spawnTimers.Add(timer);
        }

        private void SpawnMeteor(Func<Meteor> createMeteor, string meteorName)
        {
            var meteorToSpawn = _meteors[meteorName].FirstOrDefault(b => !b.IsActive);
            if (meteorToSpawn == null)
            {
                meteorToSpawn = createMeteor();
                _collisionSystem.RegisterEntity(meteorToSpawn);

                _meteors[meteorName].Add(meteorToSpawn);
            }
            meteorToSpawn.Initialize();
            meteorToSpawn.IsActive = true;
        }
    }
}