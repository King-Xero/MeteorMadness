using System;

namespace SSSRegen.Source.Game.Notifications
{
    public interface INotificationMediator : INotificationSource, INotificationPublisher, IDisposable
    {
    }
}