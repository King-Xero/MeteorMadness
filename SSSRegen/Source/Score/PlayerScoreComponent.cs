using SSSRegen.Source.GameData;

namespace SSSRegen.Source.Score
{
    public class PlayerScoreComponent : IScoreComponent
    {
        private string _scoreText;
        private int _totalScore = 0;
        
        public void Initialize(IHandleScore player)
        {
            _totalScore = 0;
            _scoreText = _totalScore.ToString(GameConstants.Player.ScoreFormat);
            player.ScoreUpdated += PlayerOnScoreUpdated;
        }

        public void Update(IHandleScore player)
        {
            _scoreText = _totalScore.ToString(GameConstants.Player.ScoreFormat);
        }

        public void Draw(IHandleScore player)
        {
            //ToDo draw _scoreText
        }

        private void PlayerOnScoreUpdated(object sender, ScoreUpdatedEventArgs e)
        {
            _totalScore += e.AddedAmount;
        }
    }
}