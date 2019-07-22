using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Collision;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Notifications;

namespace SSSRegen.Source.GameData
{
    public class GameContext
    {
        private readonly Game _game;

        public GameContext(Game game, SpriteBatch spriteBatch, IGameAudioManager gameAudioManager)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            if (spriteBatch == null) throw new ArgumentNullException(nameof(spriteBatch));
            GameGraphics = new GameGraphics(spriteBatch);
            GameAudio = gameAudioManager ?? throw new ArgumentNullException(nameof(gameAudioManager));
            Random = new Random();
            AssetManager = new AssetManager(_game);
            StateMachine = new GameStateMachine();
            Factories = new GameFactories(this, Random);
            CollisionSystem = new BasicCollisionSystem();
            NotificationMediator = new NotificationMediator();
        }

        public Rectangle ScreenBounds => new Rectangle(0, 0, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);
        public Random Random { get; }
        public IGameGraphics GameGraphics { get; }
        public IGameAudioManager GameAudio { get; }
        public IAssetManager AssetManager { get; }
        public IGameStateMachine StateMachine { get; }
        public IGameFactories Factories { get; }
        public ICollisionSystem CollisionSystem { get; }
        public INotificationMediator NotificationMediator { get; }
    }
}