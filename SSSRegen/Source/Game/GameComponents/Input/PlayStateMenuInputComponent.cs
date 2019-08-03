using System;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Input;
using SSSRegen.Source.Core.Interfaces.Menus;

namespace SSSRegen.Source.Game.GameComponents.Input
{
    public class PlayStateMenuInputComponent : GameMenuInputComponent
    {
        private readonly IInputController _inputController;

        public PlayStateMenuInputComponent(IInputController inputController) : base(inputController)
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