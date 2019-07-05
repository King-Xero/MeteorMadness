using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Score
{
    public class PlayerScoreComponent : IScoreComponent
    {
        private readonly GameContext _gameContext;

        private int _totalScore = 0;
        private Vector2 _drawPosition;
        private IUIText _scoreText;
        
        public PlayerScoreComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void Initialize(IHandleScore player)
        {
            _totalScore = 0;

            _scoreText = new UIText(
                _gameContext.AssetManager.GetFont(GameConstants.GameStates.MenuState.SelectedFontName),
                _totalScore.ToString(GameConstants.Player.ScoreFormat));

            _drawPosition = new Vector2(_gameContext.ScreenBounds.Width - _scoreText.Size.X, _gameContext.ScreenBounds.Y);

            player.ScoreUpdated += PlayerOnScoreUpdated;
        }

        public void Update(IHandleScore player)
        {
            _scoreText.Text = _totalScore.ToString(GameConstants.Player.ScoreFormat);
        }

        public void Draw(IHandleScore player)
        {
            _gameContext.GameGraphics.DrawText(_scoreText, _drawPosition, Color.White);
            //ToDo draw _scoreText
        }

        private void PlayerOnScoreUpdated(object sender, ScoreUpdatedEventArgs e)
        {
            _totalScore += e.AddedAmount;
        }
    }
}