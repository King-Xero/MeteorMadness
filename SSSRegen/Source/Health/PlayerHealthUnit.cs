using System;

namespace SSSRegen.Source.Health
{
    public class PlayerHealthUnit : IHealthUnit
    {
        private float _fillAmount;
        private const float FILL_AMOUNT_PER_HEALTH_PIECE = 0.5f;

        public PlayerHealthUnit()
        {
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

        public void Update()
        {
            //throw new NotImplementedException();
            //ToDo use FillAmount to update the sprite(s) to be drawn to represent a health unit
        }

        public void Draw()
        {
            //throw new NotImplementedException();
            //ToDo draw the sprite(s)
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