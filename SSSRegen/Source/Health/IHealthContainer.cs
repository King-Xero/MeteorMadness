﻿using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Health
{
    public interface IHealthContainer
    {
        void Initialize(IHandleHealth entity);
        void Update(IHandleHealth entity);
        void Draw();
        void Replenish(int amount);
        void Deplete(int amount);
    }
}