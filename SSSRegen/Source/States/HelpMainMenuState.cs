using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class HelpMainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IDrawableComponent<IGameState> _helpMainMenuStateGraphics;
        
        public HelpMainMenuState(GameContext gameContext, IDrawableComponent<IGameState> helpMainMenuStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _helpMainMenuStateGraphics = helpMainMenuStateGraphics ?? throw new ArgumentNullException(nameof(helpMainMenuStateGraphics));
        }

        public override void Initialize()
        {
            _helpMainMenuStateGraphics.Initialize(this);

            base.Initialize();
        }

        public override void Update(IGameTime gameTime)
        {
            _helpMainMenuStateGraphics.Update(this, gameTime);

            base.Update(gameTime);
        }

        public override void Draw(IGameTime gameTime)
        {
            _helpMainMenuStateGraphics.Draw(this, gameTime);

            base.Draw(gameTime);
        }
    }
}