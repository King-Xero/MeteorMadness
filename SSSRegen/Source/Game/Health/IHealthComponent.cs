using System;
using SSSRegen.Source.Core.Interfaces.Components;

namespace SSSRegen.Source.Game.Health
{
    public interface IHealthComponent : IDrawableComponent<IHandleHealth>
    {
        //ToDo use more detailed event args
        event EventHandler<EventArgs> Died;
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
}