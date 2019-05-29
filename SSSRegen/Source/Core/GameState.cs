using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameState : IGameState
    {
        private bool _isPaused;
        private List<IDrawableGameObject> _drawableGameObjects;

        public GameState()
        {
            GameObjects = new List<IGameObject>();
        }

        public IEnumerable<IGameObject> GameObjects { get; }

        public void Initialize()
        {
            _isPaused = false;
            foreach (var gameObject in GameObjects)
            {
                gameObject.Initialize();
            }
        }

        public void HandleInput()
        {
            foreach (var gameObject in GameObjects)
            {
                if (gameObject is IHandleInput inputGameObject)
                {
                    inputGameObject.HandleInput();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!_isPaused)
            {
                foreach (var gameObject in GameObjects)
                {
                    if (gameObject.IsEnabled)
                    {
                        gameObject.Update(gameTime);
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                if (gameObject is IDrawableGameObject drawable && drawable.IsVisible)
                {
                    drawable.Draw(gameTime);
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = true;
        }
    }
}