using System;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Input;
using SSSRegen.Source.Core.Interfaces.Menus;

namespace SSSRegen.Source.Game.GameComponents.Input
{
    public class GameMenuInputComponent : IComponent<IGameMenu>
    {
        private readonly IInputController _inputController;

        public GameMenuInputComponent(IInputController inputController)
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