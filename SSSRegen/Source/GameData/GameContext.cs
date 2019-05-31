using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameData
{
    public class GameContext
    {
        private readonly Game _game;

        public GameContext(Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            GameGraphics = new GameGraphics(new SpriteBatch(_game.GraphicsDevice));
            AssetManager = new AssetManager(_game);
        }

        public Rectangle ScreenBounds => new Rectangle(0, 0, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);
        public IGameGraphics GameGraphics { get; }
        public IAssetManager AssetManager { get; }
    }
}