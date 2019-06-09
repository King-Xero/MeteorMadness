using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.GameComponents.Input
{
    public class GameMenuInput : IInputComponent<IGameMenu>
    {
        private readonly IInputController _inputController;

        public GameMenuInput(IInputController inputController)
        {
            _inputController = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        public void Initialize(IGameMenu textMenu)
        {
        }

        public void Update(IGameMenu textMenu)
        {
            if (_inputController.IsDownButtonPressed())
            {
                textMenu.SelectedIndex++;
            }
            if (_inputController.IsUpButtonPressed())
            {
                textMenu.SelectedIndex--;
            }

            if (_inputController.IsStartButtonPressed())
            {
                textMenu.SelectCurrentItem();
            }
        }
    }
}