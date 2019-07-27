using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class MainMenuStateGraphics : IDrawableComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private IUIText _logoLine1Text;
        private IUIText _logoLine2Text;
        private IUIText _logoLine3Text;
        private ISprite _backgroundImage;
        private Vector2 _line1Position;
        private Vector2 _line1TargetPosition;
        private Vector2 _line2Position;
        private Vector2 _line2TargetPosition;
        private Vector2 _line3Position;
        private Stopwatch _stopwatch;
        private bool _canShowLine3;

        public MainMenuStateGraphics(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            //ToDo Swap sprites for text
            _logoLine1Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.LogoFontName), "Space!!!", Color.White);
            _logoLine2Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.LogoFontName), "Space!!!", Color.White);
            _logoLine3Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.LogoFontName), "Space!!!", Color.White);

            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.Textures.BackgroundTextureName));

            //_line1Position.X = -1 * _line1Sprite.Size.X;
            _line1Position.X = -_logoLine1Text.Size.X;
            _line1Position.Y = 40;
            _line1TargetPosition.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine1Text.Size.X / 2);
            _line1TargetPosition.Y = _line1Position.Y;

            _line2Position.X = _gameContext.GameGraphics.ScreenBounds.Width;
            _line2Position.Y = _line1TargetPosition.Y + _logoLine2Text.Size.Y + 40;
            _line2TargetPosition.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine2Text.Size.X / 2);
            _line2TargetPosition.Y = _line2Position.Y;

            _line3Position = new Vector2((_line2TargetPosition.X + _logoLine2Text.Size.X - _logoLine3Text.Size.X / 2) - 80,
                _line2TargetPosition.Y + _logoLine2Text.Size.Y + 40);

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Update(IGameState entity, IGameTime gameTime)
        {
            if (!_canShowLine3)
            {
                if (_line1Position.X < _line1TargetPosition.X)
                {
                    //Moves line 1 right if it is not in its final position
                    _line1Position.X += 10;
                }

                if (_line2Position.X > _line2TargetPosition.X)
                {
                    //Moves line 2 left if it is not in its final position
                    _line2Position.X -= 10;
                }
                else
                {
                    //If line 2 is in final position, show line 3
                    _canShowLine3 = true;
                }
            }
            else
            {
                // "Flash threshold"
                if (_stopwatch.Elapsed > TimeSpan.FromSeconds(1))
                {
                    _stopwatch.Restart();
                    //"Flashes" line 3 off and on
                    _logoLine3Text.IsVisible = !_logoLine3Text.IsVisible;
                }
            }
        }

        public void Draw(IGameState entity, IGameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.GameGraphics.ScreenBounds, Color.White);

            _gameContext.GameGraphics.DrawText(_logoLine1Text, _line1Position, Color.White);
            _gameContext.GameGraphics.DrawText(_logoLine2Text, _line2Position, Color.White);
            
            if (_logoLine3Text.IsVisible)
            {
                _gameContext.GameGraphics.DrawText(_logoLine1Text, _line3Position, Color.White);
            }
        }
    }
}