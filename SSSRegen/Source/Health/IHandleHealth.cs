using System;

namespace SSSRegen.Source.Health
{
    public interface IHandleHealth
    {
        event EventHandler<HealEventArgs> Healed;
        event EventHandler<DamageEventArgs> Damaged;

        int MaxHealth { get; }
        
        void Heal(int healAmount);
        void Damage(int damageAmount);
    }
}