using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class SplashStateGraphicsComponent : IDrawableComponent<IGameState>
    {
        private readonly GameContext _gameContext;
        private ISprite _backgroundImage;

        public SplashStateGraphicsComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStateConstants.SplashStateConstants.Textures.BackgroundTextureName));
        }

        public void Update(IGameState entity, IGameTime gameTime)
        {
            //Do Nothing
        }

        public void Draw(IGameState entity, IGameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.GameGraphics.ScreenBounds, Color.White);
        }
    }
}