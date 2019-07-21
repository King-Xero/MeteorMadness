using System.Threading.Tasks;

namespace SSSRegen.Source.Notifications
{
    public interface INotificationPublisher
    {
        Task PublishPlayerScoreChange(PlayerScoreNotificationArguments args);
    }
}