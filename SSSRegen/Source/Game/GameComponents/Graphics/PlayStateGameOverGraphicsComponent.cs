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
    public class PlayStateGameOverGraphicsComponent : IDrawableComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private IUIText _logoLine1Text;
        private IUIText _logoLine2Text;
        private Vector2 _line1Position;
        private Vector2 _line2Position;
        private Stopwatch _stopwatch;

        public PlayStateGameOverGraphicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _logoLine1Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName), GameConstants.GameStateConstants.PlayStateConstants.GameOverLine1Text, Color.White);
            _logoLine2Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName), GameConstants.GameStateConstants.PlayStateConstants.GameOverLine2Text, Color.White);


            _line1Position.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine1Text.Size.X / 2);
            _line1Position.Y = 40;

            _line2Position.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine2Text.Size.X / 2);
            _line2Position.Y = _line1Position.Y + _logoLine2Text.Size.Y + 40;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Update(IGameState entity, IGameTime gameTime)
        {
            // "Flash threshold"
            if (_stopwatch.Elapsed > TimeSpan.FromSeconds(GameConstants.GameStateConstants.PlayStateConstants.GameOverFlashDelay))
            {
                _stopwatch.Restart();
                //"Flashes" text off and on
                _logoLine1Text.IsVisible = !_logoLine1Text.IsVisible;
                _logoLine2Text.IsVisible = !_logoLine2Text.IsVisible;
            }
        }

        public void Draw(IGameState entity, IGameTime gameTime)
        {
            if (_logoLine1Text.IsVisible)
            {
                _gameContext.GameGraphics.DrawText(_logoLine1Text, _line1Position, Color.White);
            }
            if (_logoLine2Text.IsVisible)
            {
                _gameContext.GameGraphics.DrawText(_logoLine2Text, _line2Position, Color.White);
            }
        }
    }
}