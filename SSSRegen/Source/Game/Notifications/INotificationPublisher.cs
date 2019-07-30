using System.Threading.Tasks;

namespace SSSRegen.Source.Game.Notifications
{
    public interface INotificationPublisher
    {
        Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args);
    }
}