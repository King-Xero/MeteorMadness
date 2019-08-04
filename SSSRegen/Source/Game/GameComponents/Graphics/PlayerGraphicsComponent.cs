using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class PlayerGraphicsComponent : IDrawableComponent<IPlayer>
    {
        private readonly GameContext _gameContext;
        private readonly ISprite _playerShipSprite;
        private readonly IAnimatedSprite _thrusterSprite;
        private readonly ISprite _lightDamageSprite;
        private readonly ISprite _mediumDamageSprite;
        private readonly ISprite _heavyDamageSprite;
        
        private Sprite _activeDamageSprite;

        public PlayerGraphicsComponent(GameContext gameContext, ISprite playerShipSprite, IAnimatedSprite thrusterSprite, ISprite lightDamageSprite, ISprite mediumDamageSprite, ISprite heavyDamageSprite)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playerShipSprite = playerShipSprite ?? throw new ArgumentNullException(nameof(playerShipSprite));
            _thrusterSprite = thrusterSprite ?? throw new ArgumentNullException(nameof(thrusterSprite));
            _lightDamageSprite = lightDamageSprite ?? throw new ArgumentNullException(nameof(lightDamageSprite));
            _mediumDamageSprite = mediumDamageSprite?? throw new ArgumentNullException(nameof(mediumDamageSprite));
            _heavyDamageSprite = heavyDamageSprite ?? throw new ArgumentNullException(nameof(heavyDamageSprite));
        }

        public void Initialize(IPlayer player)
        {
            _activeDamageSprite = null;
            player.Size = _playerShipSprite.Size;
            player.Origin = _playerShipSprite.Origin;
        }

        public void Update(IPlayer player, IGameTime gameTime)
        {
            _thrusterSprite.Update(gameTime);

            //ToDo Possibly move into physics components as setting up bounds
            player.Size = _playerShipSprite.Size;
            player.Origin = _playerShipSprite.Origin;
        }

        public void Draw(IPlayer player, IGameTime gameTime)
        {
            
            _gameContext.GameGraphics.Draw(_playerShipSprite, player.Position, Color.White, player.Rotation, player.Origin);
            if (_activeDamageSprite != null)
            {
                _gameContext.GameGraphics.Draw(_activeDamageSprite, player.Position, Color.White, player.Rotation, player.Origin);
            }

            if (player.IsAccelerating)
            {
                var thrusterOrigin = new Vector2(_thrusterSprite.Origin.X, -_thrusterSprite.Size.Y - _thrusterSprite.Origin.Y / 2);
                //Offset thruster draw position by thruster sprite origin so that the sprite is centered
                _gameContext.GameGraphics.Draw(_thrusterSprite, player.Position, Color.White, player.Rotation, thrusterOrigin);
            }
        }
    }
}