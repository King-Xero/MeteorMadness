using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class PlayStatePausedGraphicsComponent : IDrawableComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private IUIText _logoLine1Text;
        private Vector2 _line1Position;

        public PlayStatePausedGraphicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _logoLine1Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName), GameConstants.GameStateConstants.PlayStateConstants.PausedText, Color.White);

            _line1Position.X = _gameContext.GameGraphics.ScreenBounds.Width / 2 - _logoLine1Text.Size.X / 2;
            _line1Position.Y = 40;
        }

        public void Update(IGameState entity, IGameTime gameTime)
        {
        }

        public void Draw(IGameState entity, IGameTime gameTime)
        {
            _gameContext.GameGraphics.DrawText(_logoLine1Text, _line1Position, Color.White);
        }
    }
}