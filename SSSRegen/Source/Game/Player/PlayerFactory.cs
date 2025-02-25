﻿using System;
using System.Collections.Generic;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Input;
using SSSRegen.Source.Core.Interfaces.Components;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameComponents.Graphics;
using SSSRegen.Source.Game.GameComponents.Input;
using SSSRegen.Source.Game.GameComponents.Physics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Health;
using SSSRegen.Source.Game.Projectiles;

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
                new HealthComponent(GameConstants.PlayerConstants.InitialMaxHealth, new PlayerHealthContainer(_gameContext)),
                new PlayerInputComponent(new KeyboardInputController()),
                new PlayerPhysicsComponent(_gameContext),
                CreatePlayerGraphics(),
                new PlayerProjectilesManager(new ProjectileFactory(_gameContext), _gameContext.CollisionSystem));
                //_gameContext.GameGraphics.PlayableCamera);
        }

        private IDrawableComponent<IPlayer> CreatePlayerGraphics()
        {
            return new PlayerGraphicsComponent(
                _gameContext,
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants
                    .Textures.RedShipTextureName)),
                new AnimatedSprite(
                    new List<ISprite>
                    {
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame1TextureName)),
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame2TextureName)),
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame3TextureName)),
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame4TextureName)),
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame5TextureName)),
                        new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.ThrusterConstants
                            .Thruster1Constants.Textures.Frame6TextureName)),
                    },
                    GameConstants.ThrusterConstants.Thruster1Constants.FrameDelay),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.LightDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.MediumDamageTextureName)),
                new Sprite(_gameContext.AssetManager.GetTexture(GameConstants.PlayerConstants.PlayerShip1Constants.Textures.HeavyDamageTextureName)));
        }
    }
}