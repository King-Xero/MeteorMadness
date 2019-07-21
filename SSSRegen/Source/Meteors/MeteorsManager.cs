using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorsManager : IGameObjectManager
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
                {GameConstants.Meteors.BigMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.MediumMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.SmallMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.TinyMeteor1.Name, new List<Meteor>()},
            };

            _spawnTimers = new List<PausableTimer>();

            for (var i = 0; i < GameConstants.Meteors.BigMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateBigMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.Meteors.BigMeteor1.Name].Add(meteor);
            }

            AddSpawnTimer(15000, _meteorFactory.CreateBigMeteor, GameConstants.Meteors.BigMeteor1.Name);

            for (var i = 0; i < GameConstants.Meteors.MediumMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateMediumMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.Meteors.MediumMeteor1.Name].Add(meteor);
            }

            AddSpawnTimer(15000, _meteorFactory.CreateMediumMeteor, GameConstants.Meteors.MediumMeteor1.Name);

            for (var i = 0; i < GameConstants.Meteors.SmallMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateSmallMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.Meteors.SmallMeteor1.Name].Add(meteor);
            }

            AddSpawnTimer(5000, _meteorFactory.CreateSmallMeteor, GameConstants.Meteors.SmallMeteor1.Name);

            for (var i = 0; i < GameConstants.Meteors.TinyMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateTinyMeteor();
                _collisionSystem.RegisterEntity(meteor);
                _meteors[GameConstants.Meteors.TinyMeteor1.Name].Add(meteor);
            }

            AddSpawnTimer(5000, _meteorFactory.CreateTinyMeteor, GameConstants.Meteors.TinyMeteor1.Name);

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