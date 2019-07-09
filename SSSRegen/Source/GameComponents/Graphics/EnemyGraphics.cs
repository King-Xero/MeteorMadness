using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class EnemyGraphics : IDrawableComponent<IGameObject>
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
            enemy.Size = _activeSprite.Size;
        }

        public void Update(IGameObject enemy, IGameTime gameTime)
        {
            _activeSprite = _eSprite;

            //ToDo add sprite "animation" here

            enemy.Size = _activeSprite.Size;
        }

        public void Draw(IGameObject enemy, IGameTime gameTime)
        {
            _gameGraphics.Draw(_activeSprite, enemy.Position, Color.White);
        }
    }
}