using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.States
{
    public class MenuState : GameState
    {
        private readonly GameContext _gameContext;

        private Sprite _line1Sprite;
        private Sprite _line2Sprite;
        private Sprite _line3Sprite;

        public MenuState(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}