using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class MainMenuStateGraphics : IGraphicsComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private ISprite _line1Sprite;
        private ISprite _line2Sprite;
        private ISprite _line3Sprite;
        private Vector2 _line1Position;
        private Vector2 _line2Position;
        private Vector2 _line3Position;
        private Stopwatch _stopwatch;

        public MainMenuStateGraphics(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName, GameConstants.GameStates.MenuState.LogoSpriteSheetFileName);

            _line1Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine1.SpriteFrames.FirstOrDefault());
            _line2Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine2.SpriteFrames.FirstOrDefault());
            _line3Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine3.SpriteFrames.FirstOrDefault());

            _line1Position.X = -1 * _line1Sprite.Width;
            _line1Position.Y = 40;
            _line2Position.X = _gameContext.ScreenBounds.Width;
            _line2Position.Y = 180;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Update(IGameState entity)
        {
            if (_line1Position.X <= (_gameContext.ScreenBounds.Width - 715) / 2)
            {
                _line1Position.X += 15; //Moves line 1 right if it is not in its final _position
            }
            if (_line2Position.X >= (_gameContext.ScreenBounds.Width - 595) / 2)
            {
                _line2Position.X -= 15; //Moves line 2 left if it is not in its final _position
            }
            else
            {
                _line3Position = new Vector2((_line2Position.X + _line2Sprite.Width - _line3Sprite.Width / 2) - 80, _line2Position.Y);
                _line3Sprite.IsVisible = true;
            }

            // "Flash threshold"
            if (_stopwatch.Elapsed > TimeSpan.FromSeconds(1))
            {
                _stopwatch.Restart();
                //"Flashes" line 3 off and on
                _line3Sprite.IsVisible = !_line3Sprite.IsVisible;
            }
        }

        public void Draw(IGameState entity)
        {
            _gameContext.GameGraphics.Draw(_line1Sprite, new Rectangle((int)_line1Position.X, (int)_line1Position.Y, _line1Sprite.Width, _line1Sprite.Height), Color.White);
            _gameContext.GameGraphics.Draw(_line2Sprite, new Rectangle((int)_line2Position.X, (int)_line2Position.Y, _line2Sprite.Width, _line2Sprite.Height), Color.White);
            if (_line3Sprite.IsVisible)
            {
                _gameContext.GameGraphics.Draw(_line3Sprite, new Rectangle((int)_line3Position.X, (int)_line3Position.Y, _line3Sprite.Width, _line3Sprite.Height), Color.White);
            }
        }
    }
}