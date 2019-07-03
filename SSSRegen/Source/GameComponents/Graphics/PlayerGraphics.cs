using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Graphics
{
    public class PlayerGraphics : IGraphicsComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly ISprite _playerShipSprite;
        private readonly ISprite _lightDamageSprite;
        private readonly ISprite _mediumDamageSprite;
        private readonly ISprite _heavyDamageSprite;
        
        private Sprite _activeDamageSprite;

        public PlayerGraphics(IGameGraphics gameGraphics, Sprite playerShipSprite, Sprite lightDamageSprite, Sprite mediumDamageSprite, Sprite heavyDamageSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _playerShipSprite = playerShipSprite ?? throw new ArgumentNullException(nameof(playerShipSprite));
            _lightDamageSprite = lightDamageSprite ?? throw new ArgumentNullException(nameof(lightDamageSprite));
            _mediumDamageSprite = mediumDamageSprite?? throw new ArgumentNullException(nameof(mediumDamageSprite));
            _heavyDamageSprite = heavyDamageSprite ?? throw new ArgumentNullException(nameof(heavyDamageSprite));
        }

        public void Initialize(IGameObject player)
        {
            _activeDamageSprite = null;
            player.Size = _playerShipSprite.Size;
        }

        public void Update(IGameObject player)
        {
            //ToDo Set damage sprites
            //if (player.Velocity.X < 0)
            //{
            //    _activeSprite = _moveLeftSprite;
            //}
            //else if (player.Velocity.X > 0)
            //{
            //    _activeSprite = _moveRightSprite;
            //}

            //ToDo Possibly move into physics components as setting up bounds
            player.Size = _playerShipSprite.Size;
        }

        public void Draw(IGameObject player)
        {
            _gameGraphics.Draw(_playerShipSprite, player.Bounds, Color.White);
            if (_activeDamageSprite != null)
            {
                _gameGraphics.Draw(_activeDamageSprite, player.Bounds, Color.White);
            }
        }
    }
}