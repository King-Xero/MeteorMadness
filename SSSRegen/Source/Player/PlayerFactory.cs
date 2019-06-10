using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly GameContext _gameContext;
        
        public PlayerFactory(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public Player CreatePlayer()
        {
            return new Player(
                CreatePlayerHealth(),
                CreatePlayerScore(),
                CreatePlayerInput(),
                CreatePlayerPhysics(),
                CreatePlayerGraphics());
        }

        private IHealthComponent CreatePlayerHealth()
        {
            return new PlayerHealthComponent(GameConstants.Player.InitialMaxHealth, new PlayerHealthContainer(CreatePlayerHealthUnits()));
        }

        private IHealthUnit[] CreatePlayerHealthUnits()
        {
            var healthUnits = new List<IHealthUnit>();

            for (int i = 0; i < GameConstants.Player.InitialMaxHealth / PlayerHealthUnit.HEALTH_PIECES_PER_UNIT; i++)
            {
                healthUnits.Add(new PlayerHealthUnit());
            }

            return healthUnits.ToArray();
        }

        private IScoreComponent CreatePlayerScore()
        {
            return new PlayerScoreComponent();
        }

        private IInputComponent<IGameObject> CreatePlayerInput()
        {
            return new PlayerInput(new KeyboardInputController(Keyboard.GetState()));
        }

        private IPhysicsComponent CreatePlayerPhysics()
        {
            return new PlayerPhysics(_gameContext);
        }

        private IGraphicsComponent<IGameObject> CreatePlayerGraphics()
        {
            var spriteSheet =_gameContext.AssetManager.GetTexture(GameConstants.GameStates.PlayState.PlayElementsSpriteSheetName);
            Sprite idleSprite = new Sprite(spriteSheet, GameConstants.Player.IdleSpriteFrames.FirstOrDefault());
            Sprite moveLeftSprite = new Sprite(spriteSheet, GameConstants.Player.IdleSpriteFrames.FirstOrDefault());
            Sprite moveRightSprite = new Sprite(spriteSheet, GameConstants.Player.IdleSpriteFrames.FirstOrDefault());
            return new PlayerGraphics(_gameContext.GameGraphics, idleSprite, moveLeftSprite, moveRightSprite);
        }
    }
}