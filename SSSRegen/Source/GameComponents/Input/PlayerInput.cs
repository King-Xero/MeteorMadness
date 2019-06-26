using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Input
{
    public class PlayerInput : IInputComponent<IGameObject>
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

        public void Update(IGameObject player)
        {
            _inputController.Update();

            if (_inputController.IsLeftButtonHeld())
            {
                player.Velocity = -GameConstants.Player.MovementVelocity;
            }
            else if (_inputController.IsRightButtonHeld())
            {
                player.Velocity = GameConstants.Player.MovementVelocity;
            }
            else
            {
                player.Velocity = Vector2.Zero;
            }

            if (_inputController.IsFireButtonPressed())
            {
                var playerObject = player as Player.Player;
                playerObject?.Shoot();
            }
        }
    }
}