using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Input;

namespace SSSRegen.Source.Game.GameComponents.Input
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

            float rotationSpeed = 0;

            if (_inputController.IsLeftButtonHeld())
            {
                //ToDo replace hard coded values with constants
                rotationSpeed -= 360;
            }
            if (_inputController.IsRightButtonHeld())
            {
                //ToDo replace hard coded values with constants
                rotationSpeed += 360;
            }

            player.RotationSpeed = rotationSpeed;

            //ToDo replace hard coded values with constants
            player.MovementSpeed = _inputController.IsUpButtonHeld() ? 500 : 0;

            if (_inputController.IsFireButtonPressed())
            {
                var playerObject = player as Player.Player;
                playerObject?.Shoot();
            }
        }
    }
}