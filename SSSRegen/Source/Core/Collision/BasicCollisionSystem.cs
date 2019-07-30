using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces.Collision;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.Collision
{
    public class BasicCollisionSystem : ICollisionSystem
    {
        private bool _isPaused;
        private List<IHandleCollisions> _entities;

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public void RegisterEntity(IHandleCollisions entity)
        {
            _entities.Add(entity);
        }

        public void Initialize()
        {
            _isPaused = false;
            _entities = new List<IHandleCollisions>();
        }

        public void Update(IGameTime gameTime)
        {
            if (_isPaused) return;
            foreach (var entity in _entities)
            {
                foreach (var otherEntity in _entities)
                {
                    if (!entity.IsActive || !otherEntity.IsActive || entity.CollisionLayer == otherEntity.CollisionLayer)
                    {
                        continue;
                    }

                    if (entity.Bounds.Intersects(otherEntity.Bounds))
                    {
                        entity.CollidedWith(otherEntity);
                        otherEntity.CollidedWith(entity);
                    }

                }
            }
        }
    }
}