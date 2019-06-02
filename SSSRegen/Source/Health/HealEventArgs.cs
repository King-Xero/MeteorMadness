using System;

namespace SSSRegen.Source.Health
{
    public class HealEventArgs : EventArgs
    {
        public int Amount;

        public HealEventArgs(int amount)
        {
            Amount = amount;
        }
    }
}