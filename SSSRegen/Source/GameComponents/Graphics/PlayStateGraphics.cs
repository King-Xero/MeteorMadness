using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class PlayStateGraphics : IGraphicsComponent<IGameState>
    {
        private readonly GameContext _gameContext;

        private ISprite _backgroundImage;

        public PlayStateGraphics(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IGameState entity)
        {
            _gameContext.AssetManager.LoadTexture(GameConstants.GameStates.PlayState.BackgroundTextureName, GameConstants.GameStates.PlayState.BackgroundTextureFileName);

            _backgroundImage = new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.BackgroundTextureName));
        }

        public void Update(IGameState entity)
        {
            
        }

        public void Draw(IGameState entity)
        {
            _gameContext.GameGraphics.Draw(_backgroundImage, _gameContext.ScreenBounds, Color.White);
        }
    }
}