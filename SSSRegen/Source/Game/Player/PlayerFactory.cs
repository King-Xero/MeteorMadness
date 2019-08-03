using System;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Input;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Entities;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Input;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Projectiles;
using SSSRegen.Source.Game.Score;

namespace SSSRegen.Source.Game.Player
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
                //_gameContext.GameGraphics.PlayableCamera);
        }

        private IHealthComponent CreatePlayerHealth()
        {
            return new HealthComponent(GameConstants.PlayerConstants.InitialMaxHealth, new PlayerHealthContainer(_gameContext));
        }

        private IScoreComponent CreatePlayerScore()
        {
            return new PlayerScoreComponent(_gameContext);
        }

        private IComponent<IPlayer> CreatePlayerInput()
        {
            return new PlayerInputComponent(new KeyboardInputController());
        }

        private IComponent<IPlayer> CreatePlayerPhysics()
        {
            return new PlayerPhysicsComponent(_gameContext);
        }

        private IDrawableComponent<IGameObject> CreatePlayerGraphics()
        {
            return new PlayerGraphicsComponent(
                _gameContext,
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.RedShipTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.LightDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.MediumDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.HeavyDamageTextureName)));
        }

        private IProjectilesManager CreatePlayerProjectileManager()
        {
            return new PlayerProjectilesManager(new ProjectileFactory(_gameContext), _gameContext.CollisionSystem);
        }
    }
}