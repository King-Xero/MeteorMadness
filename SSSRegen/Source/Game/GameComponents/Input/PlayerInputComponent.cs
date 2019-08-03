using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Input;
using SSSRegen.Source.Core.Utils;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Player;

namespace SSSRegen.Source.Game.GameComponents.Input
{
    public class PlayerInputComponent : IComponent<IPlayer>
    {
        private readonly IInputController _inputController;

        public PlayerInputComponent(IInputController inputController)
        {
            _inputController = inputController;
        }

        public void Initialize(IPlayer player)
        {
            _inputController.Initialize();
            player.IsAccelerating = false;
        }

        public void Update(IPlayer player, IGameTime gameTime)
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
            if (_inputController.IsUpButtonHeld())
            {
                player.MovementSpeed += 10 * gameTime.ElapsedGameTime.TotalSeconds.ToFloat();
                MathHelper.Clamp(player.MovementSpeed, 0, 50);
                player.IsAccelerating = true;
            }
            else
            {
                player.MovementSpeed = 0;
                player.IsAccelerating = false;
            }
            
            if (_inputController.IsFireButtonPressed())
            {
                var playerObject = player as Player.Player;
                playerObject?.Shoot();
            }
        }
    }
}