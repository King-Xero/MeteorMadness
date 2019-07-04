using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthContainer : IHealthContainer
    {
        private readonly GameContext _gameContext;
        private IHealthUnit[] _healthUnits;
        private Rectangle _drawPosition;

        public PlayerHealthContainer(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            //ToDo pass in health unit creation strategy
            //Create units in initialize method, based on max health property.
            //Use update method to check max health, and add new health units if max health has increased
        }

        public void Initialize(IHandleHealth entity)
        {
            _drawPosition = new Rectangle(_gameContext.ScreenBounds.X + 10, _gameContext.ScreenBounds.Y + 10, 0, 0);

            var healthUnits = new List<IHealthUnit>();

            for (int i = 0; i < entity.MaxHealth / PlayerHealthUnit.HEALTH_PIECES_PER_UNIT; i++)
            {
                //ToDo use creation strategy
                var texture = _gameContext.AssetManager.GetTexture(GameConstants.Player.PlayerShip1.Textures.RedLifeIconTextureName);
                var drawRect = new Rectangle(_drawPosition.X, _drawPosition.Y, texture.Width, texture.Height);
                var healthUnit = new PlayerHealthUnit(_gameContext, texture, drawRect);

                healthUnit.Initialize();
                healthUnits.Add(healthUnit);

                _drawPosition.X += drawRect.Width;
            }

            _healthUnits = healthUnits.ToArray();
        }

        public void Update(IHandleHealth entity)
        {
            foreach (var healthUnit in _healthUnits)
            {
                healthUnit.Update();
            }
        }

        public void Draw()
        {
            foreach (var healthUnit in _healthUnits)
            {
                healthUnit.Draw();
            }
        }

        public void Replenish(int numberOfHealthPieces)
        {
            foreach (var healthUnit in _healthUnits)
            {
                var toReplenish = numberOfHealthPieces < healthUnit.EmptyHealthPieces
                    ? numberOfHealthPieces
                    : healthUnit.EmptyHealthPieces;

                numberOfHealthPieces -= healthUnit.EmptyHealthPieces;
                healthUnit.Replenish(toReplenish);
                if (numberOfHealthPieces <= 0) break;
            }
        }

        public void Deplete(int numberOfHealthPieces)
        {
            foreach (var healthUnit in _healthUnits.Reverse())
            {
                var toDeplete = numberOfHealthPieces < healthUnit.FilledHealthPieces
                    ? numberOfHealthPieces
                    : healthUnit.FilledHealthPieces;

                numberOfHealthPieces -= healthUnit.FilledHealthPieces;
                healthUnit.Deplete(toDeplete);
                if (numberOfHealthPieces <= 0) break;
            }
        }
    }
}