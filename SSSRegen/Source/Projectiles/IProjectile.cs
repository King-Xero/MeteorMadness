﻿using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Projectiles
{
    public interface IProjectile : IGameObject
    {
        bool IsActive { get; set; }
    }
}