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

        public void Update(IGameObject player, IGameTime gameTime)
        {
            _inputController.Update();

            var movementVector = Vector2.Zero;

            if (_inputController.IsLeftButtonHeld())
            {
                movementVector -= GameConstants.Player.MovementVector;
            }
            if (_inputController.IsRightButtonHeld())
            {
                movementVector += GameConstants.Player.MovementVector;
            }

            player.MovementDirection = movementVector;

            if (_inputController.IsFireButtonPressed())
            {
                var playerObject = player as Player.Player;
                playerObject?.Shoot();
            }
        }
    }
}