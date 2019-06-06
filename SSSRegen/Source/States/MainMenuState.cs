using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.States
{
    public class MainMenuState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _mainMenuStateGraphics;
        private readonly IGameMenu _textMenu;
        
        public MainMenuState(GameContext gameContext, IGraphicsComponent<IGameState> mainMenuStateGraphics, IGameMenu textMenu)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _mainMenuStateGraphics = mainMenuStateGraphics ?? throw new ArgumentNullException(nameof(mainMenuStateGraphics));
            _textMenu = textMenu ?? throw new ArgumentNullException(nameof(textMenu));
        }

        public override void Initialize()
        {
            _mainMenuStateGraphics.Initialize(this);

            _textMenu.Initialize();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _mainMenuStateGraphics.Update(this);

            _textMenu.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _mainMenuStateGraphics.Draw(this);

            _textMenu.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}