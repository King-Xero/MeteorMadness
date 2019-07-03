using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthUnit : IHealthUnit
    {
        private readonly GameContext _gameContext;
        private readonly Texture2D _healthUnitTexture;
        private const float FILL_AMOUNT_PER_HEALTH_PIECE = 0.5f;

        private float _fillAmount;
        private ISprite _backgroundSprite;
        private ISprite _leftFillSprite;
        private ISprite _rightFillSprite;
        
        private Rectangle _backgroundDrawPosition;
        private Rectangle _leftFillDrawPosition;
        private Rectangle _rightFillDrawPosition;

        public PlayerHealthUnit(GameContext gameContext, Texture2D healthUnitTexture)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _healthUnitTexture = healthUnitTexture ?? throw new ArgumentNullException(nameof(healthUnitTexture));
        }

        private float FillAmount
        {
            get => _fillAmount;
            set
            {
                _fillAmount = value;

                if (_fillAmount < 0)
                {
                    _fillAmount = 0;
                }

                if (_fillAmount > 1)
                {
                    _fillAmount = 1;
                }
            }
        }

        public const int HEALTH_PIECES_PER_UNIT = 2;
        public int FilledHealthPieces => CalculateFilledHealthUnits();
        public int EmptyHealthPieces => HEALTH_PIECES_PER_UNIT - CalculateFilledHealthUnits();

        public void Initialize()
        {
            throw new NotImplementedException("Draw positions need to be set!");

            _backgroundSprite = new Sprite(_healthUnitTexture);
            _leftFillSprite = new Sprite(_healthUnitTexture, new Rectangle(0, 0, _healthUnitTexture.Width / 2, _healthUnitTexture.Height));
            _rightFillSprite = new Sprite(_healthUnitTexture, new Rectangle(_healthUnitTexture.Width / 2, 0, _healthUnitTexture.Width / 2, _healthUnitTexture.Height));
        }

        public void Update()
        {
            //Use fill amount to update the sprite(s) to be drawn to represent a health unit
            if (_fillAmount <= 0)
            {
                _leftFillSprite.IsVisible = false;
                _rightFillSprite.IsVisible = false;
            }
            else if (_fillAmount <= 0.5)
            {
                _leftFillSprite.IsVisible = true;
                _rightFillSprite.IsVisible = false;
            }
            else
            {
                _leftFillSprite.IsVisible = true;
                _rightFillSprite.IsVisible = true;
            }
        }

        public void Draw()
        {
            _gameContext.GameGraphics.Draw(_backgroundSprite, _backgroundDrawPosition, Color.Gray);

            if (_leftFillSprite.IsVisible)
            {
                _gameContext.GameGraphics.Draw(_leftFillSprite, _leftFillDrawPosition, Color.White);
            }

            if (_rightFillSprite.IsVisible)
            {
                _gameContext.GameGraphics.Draw(_rightFillSprite, _rightFillDrawPosition, Color.White);
            }
        }

        public void Replenish(int numberOfHealthPieces)
        {
            if (numberOfHealthPieces < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfHealthPieces));
            }
            FillAmount += numberOfHealthPieces * FILL_AMOUNT_PER_HEALTH_PIECE;
        }

        public void Deplete(int numberOfHealthPieces)
        {
            if (numberOfHealthPieces < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfHealthPieces));
            }
            FillAmount -= numberOfHealthPieces * FILL_AMOUNT_PER_HEALTH_PIECE;
        }

        private int CalculateFilledHealthUnits()
        {
            return (int)(FillAmount * HEALTH_PIECES_PER_UNIT);
        }
    }
}