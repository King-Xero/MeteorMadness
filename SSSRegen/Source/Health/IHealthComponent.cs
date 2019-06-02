using System;

namespace SSSRegen.Source.Health
{
    public interface IHealthComponent
    {
        //ToDo use more detailed event args
        event EventHandler<EventArgs> Died;

        void Initialize(IHandleHealth player);
        void Update(IHandleHealth player);
        void Draw(IHandleHealth player);
    }
}