using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Meteors
{
    public class MeteorsManager : IGameObject
    {
        private readonly IPlayerGameObject[] _players;
        private readonly IMeteorFactory _meteorFactory;
        private Dictionary<string, List<Meteor>> _Meteors;

        public MeteorsManager(IPlayerGameObject[] players, IMeteorFactory meteorFactory)
        {
            _players = players ?? throw new ArgumentException(nameof(players));
            _meteorFactory = meteorFactory ?? throw new ArgumentNullException(nameof(meteorFactory));

            IsEnabled = true;
        }

        public bool IsEnabled { get; set; }

        public void Initialize()
        {
            _Meteors = new Dictionary<string, List<Meteor>>
            {
                {GameConstants.Meteors.SmallMeteor.Name, new List<Meteor>()},
                {GameConstants.Meteors.MediumMeteor.Name, new List<Meteor>()},
            };

            for (var i = 0; i < GameConstants.Meteors.SmallMeteor.InitialCount; i++)
            {
                _Meteors[GameConstants.Meteors.SmallMeteor.Name].Add(_meteorFactory.CreateSmallMeteor());
            }
            for (var i = 0; i < GameConstants.Meteors.MediumMeteor.InitialCount; i++)
            {
                _Meteors[GameConstants.Meteors.MediumMeteor.Name].Add(_meteorFactory.CreateMediumMeteor());
            }

            foreach (var meteorType in _Meteors)
            {
                foreach (var meteor in meteorType.Value)
                {
                    meteor.Initialize();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var meteorType in _Meteors)
            {
                foreach (var meteor in meteorType.Value.Where(e => e.IsEnabled))
                {
                    meteor.Update(gameTime);
                    //ToDo Can Meteors collide with things other than the player?
                    foreach (var player in _players.Where(e => e.IsEnabled))
                    {
                        if (meteor.CheckCollision(player))
                        {
                            player.OnCollision(meteor);
                            meteor.OnCollision(player);
                        }
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var meteorType in _Meteors)
            {
                foreach (var meteor in meteorType.Value.Where(e => e.IsEnabled))
                {
                    meteor.Draw(gameTime);
                }
            }
        }
    }
}