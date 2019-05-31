using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class EnemyGraphics : IGraphicsComponent
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly Sprite _eSprite;

        private Sprite _activeSprite;

        public EnemyGraphics(IGameGraphics gameGraphics, Sprite eSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _eSprite = eSprite ?? throw new ArgumentNullException(nameof(eSprite));
        }

        public void Initialize(IGameObject enemy)
        {
            _activeSprite = _eSprite;
            enemy.Width = _activeSprite.Width;
            enemy.Height = _activeSprite.Height;
        }

        public void Update(IGameObject enemy)
        {
            _activeSprite = _eSprite;

            //ToDo add sprite "animation" here

            enemy.Width = _activeSprite.Width;
            enemy.Height = _activeSprite.Height;
        }

        public void Draw(IGameObject enemy)
        {
            _gameGraphics.Draw(_activeSprite, enemy.Bounds, Color.White);
        }
    }
}