using System.Threading.Tasks;

namespace SSSRegen.Source.Notifications
{
    public interface IReceiveNotifications<T>
    {
        /// <summary>
        /// Functionality to be executed when the object receives a notification from the mediator
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        Task OnNotificationReceived(T arg);
    }
}