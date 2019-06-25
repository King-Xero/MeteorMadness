using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class PlayerGraphics : IGraphicsComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly Sprite _idleSprite;
        private readonly Sprite _moveLeftSprite;
        private readonly Sprite _moveRightSprite;

        private Sprite _activeSprite;

        public PlayerGraphics(IGameGraphics gameGraphics, Sprite idleSprite, Sprite moveLeftSprite, Sprite moveRightSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _idleSprite = idleSprite ?? throw new ArgumentNullException(nameof(idleSprite));
            _moveLeftSprite = moveLeftSprite ?? throw new ArgumentNullException(nameof(moveLeftSprite));
            _moveRightSprite = moveRightSprite ?? throw new ArgumentNullException(nameof(moveRightSprite));
        }

        public void Initialize(IGameObject player)
        {
            _activeSprite = _idleSprite;
            player.Width = _activeSprite.Width;
            player.Height = _activeSprite.Height;
        }

        public void Update(IGameObject player)
        {
            _activeSprite = _idleSprite;

            if (player.HorizontalVelocity < 0)
            {
                _activeSprite = _moveLeftSprite;
            }
            else if (player.HorizontalVelocity > 0)
            {
                _activeSprite = _moveRightSprite;
            }

            //ToDo Possibly move into physics components as setting up bounds
            player.Width = _activeSprite.Width;
            player.Height = _activeSprite.Height;
        }

        public void Draw(IGameObject player)
        {
            _gameGraphics.Draw(_activeSprite, player.Bounds, Color.White);
        }
    }
}