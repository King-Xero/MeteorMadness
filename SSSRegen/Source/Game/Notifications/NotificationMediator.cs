﻿using System;
using System.Threading.Tasks;

namespace SSSRegen.Source.Game.Notifications
{
    public class NotificationMediator : INotificationMediator
    {
        private readonly NotificationChannel<PlayerScoreNotificationArguments> _playerScoreUpdateChannel = new NotificationChannel<PlayerScoreNotificationArguments>();
        private readonly NotificationChannel<MeteorDestroyedNotificationArguments> _meteorDestroyedUpdateChannel = new NotificationChannel<MeteorDestroyedNotificationArguments>();
        private readonly NotificationChannel<PlayerDamageLevel> _playerDamageLevelUpdateChannel = new NotificationChannel<PlayerDamageLevel>();
        private readonly NotificationChannel<PlayerDiedNotification> _playerDiedUpdateChannel = new NotificationChannel<PlayerDiedNotification>();

        public IDisposable SubscribeToPlayerScoreChanges(IReceiveNotifications<PlayerScoreNotificationArguments> handler)
        {
            return _playerScoreUpdateChannel.AddSubscriber(handler);
        }

        public IDisposable SubscribeToMeteorDestroyedNotifications(IReceiveNotifications<MeteorDestroyedNotificationArguments> handler)
        {
            return _meteorDestroyedUpdateChannel.AddSubscriber(handler);
        }

        public IDisposable SubscribeToPlayerDamageLevelNotifications(IReceiveNotifications<PlayerDamageLevel> handler)
        {
            return _playerDamageLevelUpdateChannel.AddSubscriber(handler);
        }

        public IDisposable SubscribeToPlayerDiedNotifications(IReceiveNotifications<PlayerDiedNotification> handler)
        {
            return _playerDiedUpdateChannel.AddSubscriber(handler);
        }

        public async Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args)
        {
            await _playerScoreUpdateChannel.PublishNotification(args).ConfigureAwait(false);
        }

        public async Task PublishMeteorDestroyed(MeteorDestroyedNotificationArguments args)
        {
            await _meteorDestroyedUpdateChannel.PublishNotification(args).ConfigureAwait(false);
        }

        public async Task PublishPlayerDamageLevel(PlayerDamageLevel damageLevel)
        {
            await _playerDamageLevelUpdateChannel.PublishNotification(damageLevel).ConfigureAwait(false);
        }

        public async Task PublishPlayerDied(PlayerDiedNotification notification)
        {
            await _playerDiedUpdateChannel.PublishNotification(notification).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _playerScoreUpdateChannel.Dispose();
        }
    }
}