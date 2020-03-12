using System;

namespace SSSRegen.Source.Game.Score
{
    public interface IHandleScore
    {
        //int TotalScore { get; set; }
        event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated;
        void UpdateScore(int scoreAmount);
    }
}