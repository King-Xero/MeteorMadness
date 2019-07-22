using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSSRegen.Source.Notifications
{
    /// <summary>
    /// Manages notifications of a given subject.
    /// </summary>
    class NotificationChannel : IDisposable
    {
        private readonly List<Func<Task>> _notificationHandlers = new List<Func<Task>>();

        /// <summary>
        /// Add an object to the list of subscribers that receive notifications via this channel.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public IDisposable AddSubscriber(Func<Task> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            if (_notificationHandlers.Contains(handler)) throw new ArgumentException("This object is already being notified of changes, previous handle has not been disposed", nameof(handler));

            _notificationHandlers.Add(handler);

            return new ActionOnDisposeAdapter(() => { _notificationHandlers.Remove(handler); });
        }

        /// <summary>
        /// Publish a notification to all subscribers of this channel.
        /// </summary>
        /// <returns></returns>
        public async Task PublishNotification()
        {
            var handlers = _notificationHandlers.ToArray();

            foreach (Func<Task> handler in handlers)
            {
                await handler();
            }
        }

        public void Dispose()
        {
            _notificationHandlers.Clear();
        }
    }

    /// <summary>
    /// Manages notifications of a given subject.
    /// </summary>
    class NotificationChannel<TArgument> : IDisposable
    {
        private readonly List<IReceiveNotifications<TArgument>> _notificationHandlers = new List<IReceiveNotifications<TArgument>>();


        /// <summary>
        /// Add an object to the list of subscribers that receive notifications via this channel.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public IDisposable AddSubscriber(IReceiveNotifications<TArgument> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            if (_notificationHandlers.Contains(handler)) throw new ArgumentException("This object is already being notified of changes, previous handle has not been disposed", nameof(handler));

            _notificationHandlers.Add(handler);

            return new ActionOnDisposeAdapter(() => { _notificationHandlers.Remove(handler); });
        }

        /// <summary>
        /// Publish a notification to all subscribers of this channel.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public async Task PublishNotification(TArgument argument)
        {
            if (argument == null) throw new ArgumentNullException(nameof(argument));

            var handlers = _notificationHandlers.ToArray();

            foreach (IReceiveNotifications<TArgument> handler in handlers)
            {
                await handler.OnNotificationReceived(argument);
            }
        }

        public void Dispose()
        {
            _notificationHandlers.Clear();
        }
    }
}
