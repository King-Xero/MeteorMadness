using System.Collections.Generic;
using System.Linq;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameStateMachine : IGameStateMachine
    {
        private Stack<IGameState> _gameStates;
        private IGameState _newState;
        private bool _isRemoving;
        private bool _isAdding;
        private bool _isReplacing;

        public GameStateMachine()
        {
            _gameStates = new Stack<IGameState>();
        }

        public IGameState ActiveState => _gameStates?.Peek();

        public void AddState(IGameState newState, bool isReplacing = true)
        {
            _isAdding = true;
            _isReplacing = isReplacing;
            _newState = newState;
        }

        public void RemoveState()
        {
            _isRemoving = true;
        }

        public void ProcessStateChanges()
        {
            if (_isRemoving && _gameStates.Any())
            {
                _gameStates.Pop();

                if (_gameStates.Any())
                {
                    _gameStates.Peek().Resume();
                }

                _isRemoving = false;
            }

            if (_isAdding)
            {
                if (_gameStates.Any())
                {
                    if (_isReplacing)
                    {
                        _gameStates.Pop();
                    }
                    else
                    {
                        _gameStates.Peek().Pause();
                    }
                }

                _gameStates.Push(_newState);
                _gameStates.Peek().Initialize();

                _isAdding = false;
            }
        }
    }
}