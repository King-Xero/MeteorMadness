using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class MeteorGraphicsComponent : IDrawableComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly ISprite _mSprite;

        private ISprite _activeSprite;

        public MeteorGraphicsComponent(IGameGraphics gameGraphics, ISprite mSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _mSprite = mSprite ?? throw new ArgumentNullException(nameof(mSprite));

            //Ensure that _active sprite is not null, as update could potentially be called before initialize
            _activeSprite = _mSprite;
        }

        public void Initialize(IGameObject meteor)
        {
            _activeSprite = _mSprite;
            meteor.Size = _activeSprite.Size;
        }

        public void Update(IGameObject meteor, IGameTime gameTime)
        {
            _activeSprite = _mSprite;

            //ToDo add sprite "animation" here

            meteor.Size = _activeSprite.Size;
        }

        public void Draw(IGameObject meteor, IGameTime gameTime)
        {
            _gameGraphics.Draw(_activeSprite, meteor.Position, Color.White, 0, _activeSprite.Origin);
        }
    }
}