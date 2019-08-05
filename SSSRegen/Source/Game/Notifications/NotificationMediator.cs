using System;
using System.Threading.Tasks;

namespace SSSRegen.Source.Game.Notifications
{
    public class NotificationMediator : INotificationMediator
    {
        private readonly NotificationChannel<PlayerScoreNotificationArguments> _playerScoreUpdateChannel = new NotificationChannel<PlayerScoreNotificationArguments>();
        private readonly NotificationChannel<MeteorDestroyedNotificationArguments> _meteorDestroyedUpdateChannel = new NotificationChannel<MeteorDestroyedNotificationArguments>();

        public IDisposable SubscribeToPlayerScoreChanges(IReceiveNotifications<PlayerScoreNotificationArguments> handler)
        {
            return _playerScoreUpdateChannel.AddSubscriber(handler);
        }

        public IDisposable SubscribeToMeteorDestroyedNotifications(IReceiveNotifications<MeteorDestroyedNotificationArguments> handler)
        {
            return _meteorDestroyedUpdateChannel.AddSubscriber(handler);
        }

        public async Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args)
        {
            await _playerScoreUpdateChannel.PublishNotification(args).ConfigureAwait(false);
        }

        public async Task PublishMeteorDestroyed(MeteorDestroyedNotificationArguments args)
        {
            await _meteorDestroyedUpdateChannel.PublishNotification(args).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _playerScoreUpdateChannel.Dispose();
        }
    }
}