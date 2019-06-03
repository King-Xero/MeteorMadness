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

        private ISprite _line1Sprite;
        private ISprite _line2Sprite;
        private ISprite _line3Sprite;
        private Vector2 _line1Position;
        private Vector2 _line2Position;
        private Vector2 _line3Position;

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

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {


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