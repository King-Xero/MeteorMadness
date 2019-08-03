using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;
using SSSRegen.Source.Core.Interfaces.Graphics;

namespace SSSRegen.Source.Game.GameComponents.Graphics
{
    public class HealthPackGraphicsComponent : IDrawableComponent<IGameObject>
    {
        private readonly IGameGraphics _gameGraphics;
        private readonly Sprite _hSprite;

        private Sprite _activeSprite;

        public HealthPackGraphicsComponent(IGameGraphics gameGraphics, Sprite hSprite)
        {
            _gameGraphics = gameGraphics ?? throw new ArgumentNullException(nameof(gameGraphics));
            _hSprite = hSprite ?? throw new ArgumentNullException(nameof(hSprite));

            //Ensure that _active sprite is not null, as update could potentially be called before initialize
            _activeSprite = _hSprite;
        }

        public void Initialize(IGameObject healthPack)
        {
            _activeSprite = _hSprite;
            healthPack.Size = _activeSprite.Size;
        }

        public void Update(IGameObject healthPack, IGameTime gameTime)
        {
            _activeSprite = _hSprite;

            //ToDo add sprite "animation" here

            healthPack.Size = _activeSprite.Size;
        }

        public void Draw(IGameObject healthPack, IGameTime gameTime)
        {
            _gameGraphics.Draw(_activeSprite, healthPack.Position, Color.White);
        }
    }
}