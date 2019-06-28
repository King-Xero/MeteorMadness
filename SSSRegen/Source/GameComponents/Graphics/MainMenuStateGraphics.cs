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

        //private ISprite _line1Sprite;
        //private ISprite _line2Sprite;
        //private ISprite _line3Sprite;
        private ISprite _backgroundImage;
        private Vector2 _line1Position;
        private Vector2 _line2Position;
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
            //_line1Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName));
            //_line2Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName));
            //_line3Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName));
            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.Textures.BackgroundTextureName));

            //_line1Position.X = -1 * _line1Sprite.Size.X;
            _line1Position.Y = 40;
            _line2Position.X = _gameContext.ScreenBounds.Width;
            _line2Position.Y = 180;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Update(IGameState entity)
        {
            //if (!_canShowLine3)
            //{
            //    if (_line1Position.X <= (_gameContext.ScreenBounds.Width - 715) / 2)
            //    {
            //        //Moves line 1 right if it is not in its final position
            //        _line1Position.X += 15;
            //    }

            //    if (_line2Position.X >= (_gameContext.ScreenBounds.Width - 595) / 2)
            //    {
            //        //Moves line 2 left if it is not in its final position
            //        _line2Position.X -= 15;
            //    }
            //    else
            //    {
            //        //If line 2 is in final position, set line 3 position
            //        _line3Position = new Vector2((_line2Position.X + _line2Sprite.Size.X - _line3Sprite.Size.X / 2) - 80,
            //            _line2Position.Y);
            //        _canShowLine3 = true;
            //    }
            //}
            //else
            //{
            //    // "Flash threshold"
            //    if (_stopwatch.Elapsed > TimeSpan.FromSeconds(1))
            //    {
            //        _stopwatch.Restart();
            //        //"Flashes" line 3 off and on
            //        _line3Sprite.IsVisible = !_line3Sprite.IsVisible;
            //    }
            //}
        }

        public void Draw(IGameState entity)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.ScreenBounds, Color.White);

            //ToDo Remove new and swap sprites for text
            //_gameContext.GameGraphics.Draw(_line1Sprite, new Rectangle((int)_line1Position.X, (int)_line1Position.Y, (int) _line1Sprite.Size.X, (int) _line1Sprite.Size.Y), Color.White);
            //_gameContext.GameGraphics.Draw(_line2Sprite, new Rectangle((int)_line2Position.X, (int)_line2Position.Y, (int) _line2Sprite.Size.X, (int) _line2Sprite.Size.Y), Color.White);
            //if (_line3Sprite.IsVisible)
            //{
            //    _gameContext.GameGraphics.Draw(_line3Sprite, new Rectangle((int)_line3Position.X, (int)_line3Position.Y, (int) _line3Sprite.Size.X, (int) _line3Sprite.Size.Y), Color.White);
            //}
        }
    }
}