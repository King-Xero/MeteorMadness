using System;
using SSSRegen.Source.Core.Interfaces.Entities;

namespace SSSRegen.Source.Game.Health
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