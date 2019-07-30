using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameData;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class PlayerGraphics : IDrawableComponent<IGameObject>
    {
        private readonly GameContext _gameContext;
        private readonly ISprite _playerShipSprite;
        private readonly ISprite _lightDamageSprite;
        private readonly ISprite _mediumDamageSprite;
        private readonly ISprite _heavyDamageSprite;
        
        private Sprite _activeDamageSprite;

        public PlayerGraphics(GameContext gameContext, Sprite playerShipSprite, Sprite lightDamageSprite, Sprite mediumDamageSprite, Sprite heavyDamageSprite)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playerShipSprite = playerShipSprite ?? throw new ArgumentNullException(nameof(playerShipSprite));
            _lightDamageSprite = lightDamageSprite ?? throw new ArgumentNullException(nameof(lightDamageSprite));
            _mediumDamageSprite = mediumDamageSprite?? throw new ArgumentNullException(nameof(mediumDamageSprite));
            _heavyDamageSprite = heavyDamageSprite ?? throw new ArgumentNullException(nameof(heavyDamageSprite));
        }

        public void Initialize(IGameObject player)
        {
            _activeDamageSprite = null;
            player.Size = _playerShipSprite.Size;
            player.Origin = _playerShipSprite.Origin;
        }

        public void Update(IGameObject player, IGameTime gameTime)
        {
            //ToDo Possibly move into physics components as setting up bounds
            player.Size = _playerShipSprite.Size;
            player.Origin = _playerShipSprite.Origin;
        }

        public void Draw(IGameObject player, IGameTime gameTime)
        {
            _gameContext.GameGraphics.Draw(_playerShipSprite, player.Position, Color.White, player.Rotation, player.Origin);
            if (_activeDamageSprite != null)
            {
                _gameContext.GameGraphics.Draw(_activeDamageSprite, player.Position, Color.White, player.Rotation, player.Origin);
            }
        }
    }
}