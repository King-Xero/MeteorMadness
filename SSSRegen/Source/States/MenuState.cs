using System;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class MenuState : GameState
    {
        private readonly GameContext _gameContext;
        private ITextMenu _menu;

        private ISprite _line1Sprite;
        private ISprite _line2Sprite;
        private ISprite _line3Sprite;
        private Vector2 _line1Position;
        private Vector2 _line2Position;
        private Vector2 _line3Position;

        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public MenuState(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public override void Initialize()
        {
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName, GameConstants.GameStates.MenuState.LogoSpriteSheetFileName);

            _line1Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine1.SpriteFrames.FirstOrDefault());
            _line2Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine2.SpriteFrames.FirstOrDefault());
            _line3Sprite = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.MenuState.LogoSpriteSheetName), GameConstants.GameStates.MenuState.LogoLine3.SpriteFrames.FirstOrDefault());

            _line1Position.X = -1 * _line1Sprite.Width;
            _line1Position.Y = 40;
            _line2Position.X = _gameContext.ScreenBounds.Width;
            _line2Position.Y = 180;
            _menu.Position = new Vector2((_gameContext.ScreenBounds.Width - _menu.Width) / 2, 330);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (!_menu.IsVisible)
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
                    _menu.IsVisible = true;
                    _menu.Enabled = true;
                    _line3Position = new Vector2((_line2Position.X + _line2Sprite.Width - _line3Sprite.Width / 2) - 80, _line2Position.Y);
                    _line3Sprite.IsVisible = true;
                }
            }
            else
            {
                _elapsedTime += gameTime.ElapsedGameTime; //Increases "elapsedTime" using elapsed game time
                if (_elapsedTime > TimeSpan.FromSeconds(1)) // "Flash threshold"
                {
                    _elapsedTime -= TimeSpan.FromSeconds(1); //Decreases "elapsedTime" below "flash threshold"
                    _line3Sprite.IsVisible = !_line3Sprite.IsVisible; //"Flashes" line 3 off and on
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_line1Sprite, new Rectangle((int) _line1Position.X, (int) _line1Position.Y, _line1Sprite.Width, _line1Sprite.Height), Color.White);
            _gameContext.GameGraphics.Draw(_line2Sprite, new Rectangle((int) _line2Position.X, (int) _line2Position.Y, _line2Sprite.Width, _line2Sprite.Height), Color.White);
            if (_line3Sprite.IsVisible)
            {
                _gameContext.GameGraphics.Draw(_line3Sprite, new Rectangle((int)_line3Position.X, (int)_line3Position.Y, _line3Sprite.Width, _line3Sprite.Height), Color.White);
            }
            base.Draw(gameTime);
        }
    }
}