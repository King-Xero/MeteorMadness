using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.GameComponents.Input
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