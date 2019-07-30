using System;
using System.Threading.Tasks;

namespace SSSRegen.Source.Game.Notifications
{
    public class NotificationMediator : INotificationMediator
    {
        private readonly NotificationChannel<PlayerScoreNotificationArguments> _playerScoreUpdateChannel = new NotificationChannel<PlayerScoreNotificationArguments>();

        public IDisposable SubscribeToPlayerScoreChanges(IReceiveNotifications<PlayerScoreNotificationArguments> handler)
        {
            return _playerScoreUpdateChannel.AddSubscriber(handler);
        }

        public async Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args)
        {
            await _playerScoreUpdateChannel.PublishNotification(args).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _playerScoreUpdateChannel.Dispose();
        }
    }
}