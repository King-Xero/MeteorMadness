using System;

namespace SSSRegen.Source.Health
{
    public interface IHandleHealth
    {
        int CurrentHealth { get; }
        int MaxHealth { get; set; }
        event EventHandler<HealEventArgs> Healed;
        event EventHandler<DamageEventArgs> Damaged;
        //ToDo use more detailed event args
        event EventHandler<EventArgs> Died;
        void Heal(int healAmount);
        void Damage(int damageAmount);
    }
}