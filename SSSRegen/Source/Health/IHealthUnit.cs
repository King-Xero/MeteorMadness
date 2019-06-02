﻿namespace SSSRegen.Source.Health
{
    public interface IHealthUnit 
    {
        int FilledHealthPieces { get; }
        int EmptyHealthPieces { get; }

        void Update();
        void Draw();
        void Replenish(int numberOfHealthPieces);
        void Deplete(int numberOfHealthPieces);
    }
}