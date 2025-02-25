﻿using System;

namespace SSSRegen.Source.Core.Interfaces.GameStateMachine
{
    public interface IGameTime
    {
        TimeSpan ElapsedGameTime { get; set; }
        TimeSpan TotalGameTime { get; set; }
    }
}