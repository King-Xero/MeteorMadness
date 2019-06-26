using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorsManager : IGameObjectManager
    {
        private readonly IMeteorFactory _meteorFactory;
        private Dictionary<string, List<Meteor>> _meteors;

        public MeteorsManager(IMeteorFactory meteorFactory)
        {
            _meteorFactory = meteorFactory ?? throw new ArgumentNullException(nameof(meteorFactory));
        }

        public void Initialize()
        {
            _meteors = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.Meteors.SmallMeteor.Name, new List<Meteor>()},
                {GameConstants.Meteors.MediumMeteor.Name, new List<Meteor>()},
            };

            for (var i = 0; i < GameConstants.Meteors.SmallMeteor.InitialCount; i++)
            {
                _meteors[GameConstants.Meteors.SmallMeteor.Name].Add(_meteorFactory.CreateSmallMeteor());
            }
            for (var i = 0; i < GameConstants.Meteors.MediumMeteor.InitialCount; i++)
            {
                _meteors[GameConstants.Meteors.MediumMeteor.Name].Add(_meteorFactory.CreateMediumMeteor());
            }

            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    meteor.Initialize();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    meteor.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var meteorType in _meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    meteor.Draw(gameTime);
                }
            }
        }
    }
}