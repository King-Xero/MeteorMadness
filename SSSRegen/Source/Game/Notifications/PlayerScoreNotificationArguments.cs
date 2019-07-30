namespace SSSRegen.Source.Game.Notifications
{
    public class PlayerScoreNotificationArguments
    {
        public int ScoreAmount { get; }

        public PlayerScoreNotificationArguments(int scoreAmount)
        {
            ScoreAmount = scoreAmount;
        }
    }
}