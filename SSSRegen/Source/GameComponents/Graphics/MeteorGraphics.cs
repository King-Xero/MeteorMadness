using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class MeteorGraphics : IGraphicsComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly Sprite _mSprite;

        private Sprite _activeSprite;

        public MeteorGraphics(IGameGraphics gameGraphics, Sprite mSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _mSprite = mSprite ?? throw new ArgumentNullException(nameof(mSprite));
        }

        public void Initialize(IGameObject meteor)
        {
            _activeSprite = _mSprite;
            meteor.Width = _activeSprite.Width;
            meteor.Height = _activeSprite.Height;
        }

        public void Update(IGameObject meteor)
        {
            _activeSprite = _mSprite;

            //ToDo add sprite "animation" here

            meteor.Width = _activeSprite.Width;
            meteor.Height = _activeSprite.Height;
        }

        public void Draw(IGameObject meteor)
        {
            _gameGraphics.Draw(_activeSprite, meteor.Bounds, Color.White);
        }
    }
}