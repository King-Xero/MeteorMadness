using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Input
{
    public class PlayerInput : IComponent<IGameObject>
    {
        private readonly IInputController _inputController;

        public PlayerInput(IInputController inputController)
        {
            _inputController = inputController;
        }

        public void Initialize(IGameObject player)
        {
            _inputController.Initialize();
        }

        public void Update(IGameObject player, GameTime gameTime)
        {
            _inputController.Update();

            if (_inputController.IsLeftButtonHeld())
            {
                player.MovementDirection = -GameConstants.Player.MovementVector;
            }
            else if (_inputController.IsRightButtonHeld())
            {
                player.MovementDirection = GameConstants.Player.MovementVector;
            }
            else
            {
                player.MovementDirection = Vector2.Zero;
            }

            if (_inputController.IsFireButtonPressed())
            {
                var playerObject = player as Player.Player;
                playerObject?.Shoot();
            }
        }
    }
}