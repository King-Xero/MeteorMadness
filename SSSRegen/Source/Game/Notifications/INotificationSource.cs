using System;

namespace SSSRegen.Source.Game.Notifications
{
    public interface INotificationSource
    {
        IDisposable SubscribeToPlayerScoreChanges(IReceiveNotifications<PlayerScoreNotificationArguments> handler);
        IDisposable SubscribeToMeteorDestroyedNotifications(IReceiveNotifications<MeteorDestroyedNotificationArguments> handler);
        IDisposable SubscribeToPlayerDamageLevelNotifications(IReceiveNotifications<PlayerDamageLevel> handler);
        IDisposable SubscribeToPlayerDiedNotifications(IReceiveNotifications<PlayerDiedNotification> handler);
    }
}