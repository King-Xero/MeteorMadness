using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Menus;

namespace SSSRegen.Source.States
{
    public class PlayState : GameState
    {
        private readonly GameContext _gameContext;
        private readonly IGraphicsComponent<IGameState> _playStateGraphics;

        private IGameMenu _playStateMenu;
        private bool _isTwoPlayer;
        private bool _isPaused;
        private bool _isGameOver;
        
        public PlayState(GameContext gameContext, IGraphicsComponent<IGameState> playStateGraphics)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _playStateGraphics = playStateGraphics ?? throw new ArgumentNullException(nameof(playStateGraphics));
        }

        public override void Initialize()
        {
            _playStateGraphics.Initialize(this);
            _playStateMenu = _gameContext.MenuFactory.CreatePlayStateMenu();
            _playStateMenu.Initialize();
            //_enemies.Initialize();
            //_meteors.Initialize();
            //_bonuses.Initialize();
            //_players.Initialize();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _playStateGraphics.Update(this);
            _playStateMenu.Update(gameTime);
            //_enemies.Update();
            //_meteors.Update();
            //_bonuses.Update();
            //_players.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _playStateGraphics.Draw(this);
            _playStateMenu.Draw(gameTime);
            //_enemies.Draw();
            //_meteors.Draw();
            //_bonuses.Draw();
            //_players.Draw();

            base.Draw(gameTime);
        }
    }
}