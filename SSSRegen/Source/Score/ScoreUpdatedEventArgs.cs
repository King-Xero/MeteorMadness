﻿namespace SSSRegen.Source.Score
{
    public class ScoreUpdatedEventArgs
    {
        public int AddedAmount;
        //public int TotalScore;

        public ScoreUpdatedEventArgs(int addedAmount) //, int totalScore)
        {
            AddedAmount = addedAmount;
            //TotalScore = totalScore;
        }
    }
}