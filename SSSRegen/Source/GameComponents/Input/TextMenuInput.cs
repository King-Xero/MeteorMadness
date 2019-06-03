using System;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.GameComponents.Input
{
    public class TextMenuInput : ITextMenuInputComponent
    {
        private readonly IInputController _inputController;

        public TextMenuInput(IInputController inputController)
        {
            _inputController = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        public void Initialize(ITextMenu textMenu)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ITextMenu textMenu)
        {
            if (_inputController.IsDownButtonPressed())
            {
                textMenu.SelectedIndex++;
            }
            if (_inputController.IsUpButtonPressed())
            {
                textMenu.SelectedIndex--;
            }
        }
    }
}