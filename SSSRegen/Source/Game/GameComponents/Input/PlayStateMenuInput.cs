using System;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Input;
using SSSRegen.Source.Core.Interfaces.Menus;

namespace SSSRegen.Source.Game.GameComponents.Input
{
    public class PlayStateMenuInput : GameMenuInput
    {
        private readonly IInputController _inputController;

        public PlayStateMenuInput(IInputController inputController) : base(inputController)
        {
            _inputController = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        public override void Update(IGameMenu textMenu, IGameTime gameTime)
        {
            base.Update(textMenu, gameTime);

            if (_inputController.IsEscapeButtonPressed())
            {
                textMenu.IsEnabled = !textMenu.IsEnabled;
            }
        }
    }
}