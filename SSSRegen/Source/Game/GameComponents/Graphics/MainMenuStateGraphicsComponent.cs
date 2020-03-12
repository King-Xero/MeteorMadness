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
    public class MainMenuStateGraphicsComponent : IDrawableComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private IUIText _logoLine1Text;
        private IUIText _logoLine2Text;
        private ISprite _backgroundImage;
        private Vector2 _line1Position;
        private Vector2 _line1TargetPosition;
        private Vector2 _line2Position;
        private Vector2 _line2TargetPosition;

        public MainMenuStateGraphicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _logoLine1Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName), GameConstants.GameStateConstants.MenuStateConstants.GameTitleLine1Text, Color.White);
            _logoLine2Text = new UIText(_gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.LogoFontName), GameConstants.GameStateConstants.MenuStateConstants.GameTitleLine2Text, Color.White);

            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStateConstants.MenuStateConstants.Textures.BackgroundTextureName));

            _line1Position.X = -_logoLine1Text.Size.X;
            _line1Position.Y = 40;
            _line1TargetPosition.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine1Text.Size.X / 2);
            _line1TargetPosition.Y = _line1Position.Y;

            _line2Position.X = _gameContext.GameGraphics.ScreenBounds.Width;
            _line2Position.Y = _line1TargetPosition.Y + _logoLine2Text.Size.Y + 40;
            _line2TargetPosition.X = (_gameContext.GameGraphics.ScreenBounds.Width / 2) - (_logoLine2Text.Size.X / 2);
            _line2TargetPosition.Y = _line2Position.Y;
        }

        public void Update(IGameState entity, IGameTime gameTime)
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
        }

        public void Draw(IGameState entity, IGameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.GameGraphics.ScreenBounds, Color.White);

            _gameContext.GameGraphics.DrawText(_logoLine1Text, _line1Position, Color.White);
            _gameContext.GameGraphics.DrawText(_logoLine2Text, _line2Position, Color.White);
        }
    }
}