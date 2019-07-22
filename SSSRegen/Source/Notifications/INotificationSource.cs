using System;

namespace SSSRegen.Source.Notifications
{
    public interface INotificationSource
    {
        IDisposable SubscribeToPlayerScoreChanges(IReceiveNotifications<PlayerScoreNotificationArguments> handler);
    }
}