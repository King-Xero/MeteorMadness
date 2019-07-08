using System;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.GameComponents.Input
{
    public class GameMenuInput : IComponent<IGameMenu>
    {
        private readonly IInputController _inputController;

        public GameMenuInput(IInputController inputController)
        {
            _inputController = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        public virtual void Initialize(IGameMenu textMenu)
        {
            _inputController.Initialize();
        }

        public virtual void Update(IGameMenu textMenu, IGameTime gameTime)
        {
            _inputController.Update();

            if (textMenu.IsEnabled && _inputController.IsDownButtonPressed())
            {
                textMenu.SelectedIndex++;
            }
            if (textMenu.IsEnabled && _inputController.IsUpButtonPressed())
            {
                textMenu.SelectedIndex--;
            }
            if (textMenu.IsEnabled && _inputController.IsStartButtonPressed())
            {
                textMenu.SelectCurrentItem();
            }
        }
    }
}