﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Menus;
using SSSRegen.Source.Notifications;

namespace SSSRegen.Source.GameData
{
    public class GameContext
    {
        private readonly Game _game;

        public GameContext(Game game, SpriteBatch spriteBatch, IResolution resolution, IGameAudioManager gameAudioManager)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            if (spriteBatch == null) throw new ArgumentNullException(nameof(spriteBatch));
            if (resolution == null) throw new ArgumentNullException(nameof(resolution));
            GameGraphics = new GameGraphics(spriteBatch, resolution, new TrackingCamera2D(this){Zoom = 1f});
            GameAudio = gameAudioManager ?? throw new ArgumentNullException(nameof(gameAudioManager));
            Random = new Random();
            AssetManager = new AssetManager(_game);
            StateMachine = new GameStateMachine();
            MenuFactory = new MenuFactory(this);
            CollisionSystem = new BasicCollisionSystem();
            NotificationMediator = new NotificationMediator();
        }

        public Random Random { get; }
        public IGameGraphics GameGraphics { get; }
        public IGameAudioManager GameAudio { get; }
        public IAssetManager AssetManager { get; }
        public IGameStateMachine StateMachine { get; }
        public IMenuFactory MenuFactory { get; }
        public ICollisionSystem CollisionSystem { get; }
        public INotificationMediator NotificationMediator { get; }
    }
}