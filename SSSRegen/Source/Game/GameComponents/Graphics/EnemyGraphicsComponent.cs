using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class EnemyGraphicsComponent : IDrawableComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly ISprite _eSprite;

        private ISprite _activeSprite;

        public EnemyGraphicsComponent(IGameGraphics gameGraphics, ISprite eSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _eSprite = eSprite ?? throw new ArgumentNullException(nameof(eSprite));

            //Ensure that _active sprite is not null, as update could potentially be called before initialize
            _activeSprite = _eSprite;
        }

        public void Initialize(IGameObject enemy)
        {
            _activeSprite = _eSprite;
            enemy.Size = _activeSprite.Size;
        }

        public void Update(IGameObject enemy, IGameTime gameTime)
        {
            _activeSprite = _eSprite;

            //ToDo add sprite "animation" here

            enemy.Size = _activeSprite.Size;
        }

        public void Draw(IGameObject enemy, IGameTime gameTime)
        {
            _gameGraphics.Draw(_activeSprite, enemy.Position, Color.White, 0, _activeSprite.Origin);
        }
    }
}