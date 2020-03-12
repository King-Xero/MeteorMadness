using System.Threading.Tasks;

namespace SSSRegen.Source.Game.Notifications
{
    public interface INotificationPublisher
    {
        Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args);
        Task PublishMeteorDestroyed(MeteorDestroyedNotificationArguments args);
        Task PublishPlayerDamageLevel(PlayerDamageLevel damageLevel);
        Task PublishPlayerDied(PlayerDiedNotification notification);
    }
}