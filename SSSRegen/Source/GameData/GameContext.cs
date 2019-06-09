using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.GameData
{
    public class GameContext
    {
        private readonly Game _game;

        public GameContext(Game game, SpriteBatch spriteBatch)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Random = new Random();
            GameGraphics = new GameGraphics(spriteBatch);
            AssetManager = new AssetManager(_game);
            StateMachine = new GameStateMachine();
            Factories = new GameFactories(this, Random);
        }

        public Rectangle ScreenBounds => new Rectangle(0, 0, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);
        public Random Random { get; }
        public IGameGraphics GameGraphics { get; }
        public IAssetManager AssetManager { get; }
        public IGameStateMachine StateMachine { get; }
        public IGameFactories Factories { get; }
    }
}