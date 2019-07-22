using System;

namespace SSSRegen.Source.Notifications
{
    public interface INotificationMediator : INotificationSource, INotificationPublisher, IDisposable
    {
    }
}