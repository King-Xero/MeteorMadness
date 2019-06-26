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

        public virtual void Update(GameTime gameTime)
        {
            if (!_isPaused)
            {
                foreach (var gameObject in GameObjects)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        public virtual void Draw(GameTime gameTime)
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