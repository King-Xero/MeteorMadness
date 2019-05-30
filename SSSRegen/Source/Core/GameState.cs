using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Core
{
    public class GameState : IGameState
    {
        private bool _isPaused;
        
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

        public void Update()
        {
            if (!_isPaused)
            {
                foreach (var gameObject in GameObjects)
                {
                    gameObject.Update();
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Draw(gameTime);
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