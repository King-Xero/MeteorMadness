using System;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Projectiles;
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
                _gameContext,
                CreatePlayerHealth(),
                CreatePlayerInput(),
                CreatePlayerPhysics(),
                CreatePlayerGraphics(),
                CreatePlayerProjectileManager());
        }

        private IHealthComponent CreatePlayerHealth()
        {
            return new HealthComponent(GameConstants.Player.InitialMaxHealth, new PlayerHealthContainer(_gameContext));
        }

        private IScoreComponent CreatePlayerScore()
        {
            return new PlayerScoreComponent(_gameContext);
        }

        private IComponent<IGameObject> CreatePlayerInput()
        {
            return new PlayerInput(new KeyboardInputController());
        }

        private IComponent<IGameObject> CreatePlayerPhysics()
        {
            return new PlayerPhysics(_gameContext);
        }

        private IDrawableComponent<IGameObject> CreatePlayerGraphics()
        {
            return new PlayerGraphics(
                _gameContext,
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.RedShipTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.LightDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.MediumDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.HeavyDamageTextureName)));
        }

        private IProjectilesManager CreatePlayerProjectileManager()
        {
            return new PlayerProjectilesManager(new ProjectileFactory(_gameContext), _gameContext.CollisionSystem);
        }
    }
}