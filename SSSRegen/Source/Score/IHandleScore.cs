using System;

namespace SSSRegen.Source.Score
{
    public interface IHandleScore
    {
        //int TotalScore { get; set; }
        event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated;
        void UpdateScore(int scoreAmount);
    }
}