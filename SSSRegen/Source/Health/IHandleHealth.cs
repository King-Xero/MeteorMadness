using System;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Health
{
    public interface IHandleHealth : IGameObject
    {
        event EventHandler<HealEventArgs> Healed;
        event EventHandler<DamageEventArgs> Damaged;

        int MaxHealth { get; }
        
        void Heal(int healAmount);
        void Damage(int damageAmount);
    }
}