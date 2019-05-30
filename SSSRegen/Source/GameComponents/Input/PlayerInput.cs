using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.GameComponents.Input
{
    public class PlayerInput : IInputComponent
    {
        private readonly IInputController _inputController;

        public PlayerInput(IInputController inputController)
        {
            _inputController = inputController;
        }

        public void Initialize(IGameObject player)
        {
            
        }

        public void Update(IGameObject player)
        {
            if (_inputController.IsLeftButtonPressed())
            {
                player.HorizontalVelocity -= GameConstants.Player.MovementVelocity;
            }
            else if (_inputController.IsRightButtonPressed())
            {
                player.HorizontalVelocity += GameConstants.Player.MovementVelocity;
            }
        }
    }
}