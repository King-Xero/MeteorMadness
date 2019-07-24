using System;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Health
{
    public interface IHealthComponent : IDrawableComponent<IHandleHealth>
    {
        //ToDo use more detailed event args
        event EventHandler<EventArgs> Died;
    }
}