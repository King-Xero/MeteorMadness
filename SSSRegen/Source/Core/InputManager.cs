using System;
using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class InputManager : IInputManager
    {
        private KeyboardState _keyboardState;

        public InputManager(KeyboardState keyboardState)
        {
            _keyboardState = keyboardState;
        }

        public bool IsLeftButtonPressed()
        {
            return _keyboardState.IsKeyDown(Keys.A) || _keyboardState.IsKeyDown(Keys.Left);
        }

        public bool IsRightButtonPressed()
        {
            return _keyboardState.IsKeyDown(Keys.D) || _keyboardState.IsKeyDown(Keys.Right);
        }

        public bool IsUpButtonPressed()
        {
            return _keyboardState.IsKeyDown(Keys.W) || _keyboardState.IsKeyDown(Keys.Up);
        }

        public bool IsDownButtonPressed()
        {
            return _keyboardState.IsKeyDown(Keys.S) || _keyboardState.IsKeyDown(Keys.Down);
        }

        public bool IsStartButtonPressed()
        {
            return _keyboardState.IsKeyDown(Keys.Enter);
        }
    }
}