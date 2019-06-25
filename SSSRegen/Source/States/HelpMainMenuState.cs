using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class HelpMainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _helpMainMenuStateGraphics;
        
        public HelpMainMenuState(GameContext gameContext, IGraphicsComponent<IGameState> helpMainMenuStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _helpMainMenuStateGraphics = helpMainMenuStateGraphics ?? throw new ArgumentNullException(nameof(helpMainMenuStateGraphics));
        }

        public override void Initialize()
        {
            _helpMainMenuStateGraphics.Initialize(this);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _helpMainMenuStateGraphics.Update(this);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _helpMainMenuStateGraphics.Draw(this);

            base.Draw(gameTime);
        }
    }
}