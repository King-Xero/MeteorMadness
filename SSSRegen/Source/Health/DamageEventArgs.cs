using System;

namespace SSSRegen.Source.Health
{
    public class DamageEventArgs : EventArgs
    {
        public int Amount;

        public DamageEventArgs(int amount)
        {
            Amount = amount;
        }
    }
}