using System;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core.Assets;
using SSSRegen.Source.Core.Camera;
using SSSRegen.Source.Core.Collision;
using SSSRegen.Source.Core.GameStateMachine;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Assets;
using SSSRegen.Source.Core.Interfaces.Audio;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.Menus;
using SSSRegen.Source.Game.Notifications;

namespace SSSRegen.Source.Game.GameData
{
    public class GameContext
    {
        private readonly Microsoft.Xna.Framework.Game _game;

        public GameContext(Microsoft.Xna.Framework.Game game, SpriteBatch spriteBatch, IScreenSizeManager screenSizeManager, IGameAudioManager gameAudioManager)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            if (spriteBatch == null) throw new ArgumentNullException(nameof(spriteBatch));
            if (screenSizeManager == null) throw new ArgumentNullException(nameof(screenSizeManager));
            GameGraphics = new GameGraphics(spriteBatch, screenSizeManager, new TrackingCamera2D(this){Zoom = 1f});
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
        public Action QuitGame => () => _game.Exit();
    }
}