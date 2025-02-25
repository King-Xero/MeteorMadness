﻿using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.GameStateMachine
{
    public class GameState : IGameState
    {
        private bool _isPaused;
        
        public GameState()
        {
            GameObjects = new List<IGameObject>();
        }

        //ToDo "Objects" in the scene should be added to collection to call 
        public IEnumerable<IGameObject> GameObjects { get; }

        public virtual void Initialize()
        {
            _isPaused = false;
            foreach (var gameObject in GameObjects)
            {
                gameObject.Initialize();
            }
        }

        public virtual void Update(IGameTime gameTime)
        {
            if (!_isPaused)
            {
                foreach (var gameObject in GameObjects)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        public virtual void Draw(IGameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Draw(gameTime);
            }
        }

        public virtual void Pause()
        {
            _isPaused = true;
        }

        public virtual void Resume()
        {
            _isPaused = true;
        }
    }
}