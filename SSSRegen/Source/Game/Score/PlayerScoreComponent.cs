using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core.Graphics;
using SSSRegen.Source.Core.Interfaces.Graphics;
using SSSRegen.Source.Game.GameData;
using SSSRegen.Source.Game.Notifications;

namespace SSSRegen.Source.Game.Score
{
    public class PlayerScoreComponent : IScoreComponent, IReceiveNotifications<PlayerScoreNotificationArguments>, IDisposable
    {
        private readonly GameContext _gameContext;

        private int _totalScore = 0;
        private Vector2 _drawPosition;
        private IUIText _scoreText;
        private IDisposable _scoreHandler;

        public PlayerScoreComponent(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));

        }

        public void Initialize()
        {
            _scoreHandler = _gameContext.NotificationMediator.SubscribeToPlayerScoreChanges(this);

            _totalScore = 0;

            _scoreText = new UIText(
                _gameContext.AssetManager.GetFont(GameConstants.GameStateConstants.MenuStateConstants.SelectedFontName),
                _totalScore.ToString(GameConstants.PlayerConstants.ScoreFormat));

            _drawPosition = new Vector2(_gameContext.GameGraphics.ScreenBounds.Width - _scoreText.Size.X, _gameContext.GameGraphics.ScreenBounds.Y);
        }

        public void Update()
        {
            _scoreText.Text = _totalScore.ToString(GameConstants.PlayerConstants.ScoreFormat);
        }

        public void Draw()
        {
            _gameContext.GameGraphics.DrawText(_scoreText, _drawPosition, Color.White);
        }

        public Task OnNotificationReceived(PlayerScoreNotificationArguments arg)
        {
            _totalScore += arg.ScoreAmount;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //ToDo dispose handler in unload/clean up method
            _scoreHandler?.Dispose();
        }
    }
}