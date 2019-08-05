using Microsoft.Xna.Framework;
using SSSRegen.Source.Game.Meteors;

namespace SSSRegen.Source.Game.Notifications
{
    public class MeteorDestroyedNotificationArguments
    {
        public MeteorType MeteorType { get; }
        public Vector2 Position { get; }

        public MeteorDestroyedNotificationArguments(MeteorType meteorType, Vector2 position)
        {
            MeteorType = meteorType;
            Position = position;
        }
    }
}