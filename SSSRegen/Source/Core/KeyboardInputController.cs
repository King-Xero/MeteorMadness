using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class KeyboardInputController : IInputController
    {
        private KeyboardState _oldKeyboardState;
        private KeyboardState _newKeyboardState;

        public KeyboardInputController()
        {
        }

        public void Initialize()
        {
            _newKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            _oldKeyboardState = _newKeyboardState;
            _newKeyboardState = Keyboard.GetState();
        }

        public bool IsLeftButtonPressed()
        {
            return IsKeyPressed(Keys.A) || IsKeyPressed(Keys.Left);
        }

        public bool IsRightButtonPressed()
        {
            return IsKeyPressed(Keys.D) || IsKeyPressed(Keys.Right);
        }

        public bool IsUpButtonPressed()
        {
            return IsKeyPressed(Keys.W) || IsKeyPressed(Keys.Up);
        }

        public bool IsDownButtonPressed()
        {
            return IsKeyPressed(Keys.S) || IsKeyPressed(Keys.Down);
        }

        public bool IsStartButtonPressed()
        {
            return IsKeyPressed(Keys.Enter);
        }

        private bool IsKeyPressed(Keys key)
        {
            return _oldKeyboardState.IsKeyDown(key) && _newKeyboardState.IsKeyUp(key);
        }
    }
}