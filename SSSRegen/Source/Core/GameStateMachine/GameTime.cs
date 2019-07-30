using System;
using SSSRegen.Source.Core.Interfaces.GameStateMachine;

namespace SSSRegen.Source.Core.GameStateMachine
{
    public class GameTime : IGameTime
    {
        public TimeSpan ElapsedGameTime { get; set; }
        public TimeSpan TotalGameTime { get; set; }
    }
}