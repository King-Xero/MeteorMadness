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

        public bool IsLeftButtonHeld()
        {
            return IsKeyHeld(Keys.A) || IsKeyHeld(Keys.Left);
        }

        public bool IsRightButtonPressed()
        {
            return IsKeyPressed(Keys.D) || IsKeyPressed(Keys.Right);
        }

        public bool IsRightButtonHeld()
        {
            return IsKeyHeld(Keys.D) || IsKeyHeld(Keys.Right);
        }

        public bool IsUpButtonPressed()
        {
            return IsKeyPressed(Keys.W) || IsKeyPressed(Keys.Up);
        }

        public bool IsUpButtonHeld()
        {
            return IsKeyHeld(Keys.W) || IsKeyHeld(Keys.Up);
        }

        public bool IsDownButtonPressed()
        {
            return IsKeyPressed(Keys.S) || IsKeyPressed(Keys.Down);
        }

        public bool IsDownButtonHeld()
        {
            return IsKeyHeld(Keys.S) || IsKeyHeld(Keys.Down);
        }

        public bool IsStartButtonPressed()
        {
            return IsKeyPressed(Keys.Enter);
        }

        public bool IsEscapeButtonPressed()
        {
            return IsKeyPressed(Keys.Escape);
        }

        public bool IsFireButtonPressed()
        {
            return IsKeyPressed(Keys.Space);
        }

        private bool IsKeyPressed(Keys key)
        {
            return _oldKeyboardState.IsKeyUp(key) && _newKeyboardState.IsKeyDown(key);
        }

        private bool IsKeyHeld(Keys key)
        {
            return _oldKeyboardState.IsKeyDown(key) && _newKeyboardState.IsKeyDown(key);
        }
    }
}