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
                {GameConstants.Meteors.BigMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.MediumMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.SmallMeteor1.Name, new List<Meteor>()},
                {GameConstants.Meteors.TinyMeteor1.Name, new List<Meteor>()},
            };

            for (var i = 0; i < GameConstants.Meteors.BigMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateBigMeteor();
                meteor.Initialize();

                _meteors[GameConstants.Meteors.BigMeteor1.Name].Add(meteor);
            }
            for (var i = 0; i < GameConstants.Meteors.MediumMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateMediumMeteor();
                meteor.Initialize();

                _meteors[GameConstants.Meteors.MediumMeteor1.Name].Add(meteor);
            }
            for (var i = 0; i < GameConstants.Meteors.SmallMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateSmallMeteor();
                meteor.Initialize();

                _meteors[GameConstants.Meteors.SmallMeteor1.Name].Add(meteor);
            }
            for (var i = 0; i < GameConstants.Meteors.TinyMeteor1.InitialCount; i++)
            {
                var meteor = _meteorFactory.CreateTinyMeteor();
                meteor.Initialize();

                _meteors[GameConstants.Meteors.TinyMeteor1.Name].Add(meteor);
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