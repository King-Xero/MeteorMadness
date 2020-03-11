using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Notifications;

namespace SSSRegen.Source.Game.Meteors
{
    public class MeteorsManager : IGameObjectManager, IReceiveNotifications<MeteorDestroyedNotificationArguments>, IDisposable
    {
        private readonly GameContext _gameContext;
        private readonly IMeteorFactory _meteorFactory;
        private readonly ICollisionSystem _collisionSystem;
        private readonly SoundEffect _incomingSoundEffect;

        private Dictionary<string, List<Meteor>> _meteors;
        private Dictionary<string, List<Meteor>> _meteorsToAdd;
        private bool _isPaused;
        private IDisposable _meteorDestroyedHandler;
        private bool _canSpawnWave;
        private TimeSpan _elapsedWaveTime;
        private int _numberOfMeteorsToSpawn;

        public MeteorsManager(GameContext gameContext, IMeteorFactory meteorFactory, ICollisionSystem collisionSystem, SoundEffect incomingSoundEffect)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _meteorFactory = meteorFactory ?? throw new ArgumentNullException(nameof(meteorFactory));
            _collisionSystem = collisionSystem ?? throw new ArgumentNullException(nameof(collisionSystem));
            _incomingSoundEffect = incomingSoundEffect ?? throw new ArgumentNullException(nameof(incomingSoundEffect));
        }

        public void Initialize()
        {
            _meteorDestroyedHandler = _gameContext.NotificationMediator.SubscribeToMeteorDestroyedNotifications(this);

            _meteors = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Name, new List<Meteor>()},
            };

            _meteorsToAdd = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Name, new List<Meteor>()},
                {GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Name, new List<Meteor>()},
            };

            _numberOfMeteorsToSpawn = GameConstants.MeteorConstants.InitialWaveCount;
            _elapsedWaveTime = TimeSpan.Zero;
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;

            if (_canSpawnWave)
            {
                _elapsedWaveTime += gameTime.ElapsedGameTime;

                //ToDo Indicate that next wave is about to start (Text/warning alarm)
                if (_elapsedWaveTime >= GameConstants.MeteorConstants.MeteorSpawnDelay)
                {
                    _canSpawnWave = false;
                    _elapsedWaveTime = TimeSpan.Zero;

                    SpawnNextWave();
                }
            }

            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    if (meteor.IsActive)
                    {
                        _canSpawnWave = false;
                        meteor.Update(gameTime);
                    }
                }
            }

            foreach (var meteorType in _meteorsToAdd)
            {
                _meteors[meteorType.Key].AddRange(meteorType.Value);
                meteorType.Value.Clear();
            }

            if (!_meteors.Any(d => d.Value.Any(m => m.IsActive)))
            {
                _canSpawnWave = true;
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
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public Task OnNotificationReceived(MeteorDestroyedNotificationArguments args)
        {
            switch (args.MeteorType)
            {
                case MeteorType.Tiny:
                    break;
                case MeteorType.Small:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateTinyMeteor, GameConstants.MeteorConstants.TinyMeteorConstants.TinyMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                case MeteorType.Medium:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateSmallMeteor, GameConstants.MeteorConstants.SmallMeteorConstants.SmallMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                case MeteorType.Big:
                    for (int i = 0; i < GameConstants.MeteorConstants.NumMeteorsSpawnedWhenDestroyed; i++)
                    {
                        var meteor = SpawnMeteor(_meteorFactory.CreateMediumMeteor, GameConstants.MeteorConstants.MediumMeteorConstants.MediumMeteor1Constants.Name);
                        meteor.Position = args.Position;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //ToDo Spawn particles
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //ToDo dispose handler in unload/clean up method
            _meteorDestroyedHandler?.Dispose();
        }

        private void SpawnNextWave()
        {
            _gameContext.GameAudio.PlaySoundEffect(_incomingSoundEffect);

            for (int i = 0; i < _numberOfMeteorsToSpawn; i++)
            {
                SpawnMeteor(_meteorFactory.CreateBigMeteor, GameConstants.MeteorConstants.BigMeteorConstants.BigMeteor1Constants.Name);
            }

            _numberOfMeteorsToSpawn++;
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