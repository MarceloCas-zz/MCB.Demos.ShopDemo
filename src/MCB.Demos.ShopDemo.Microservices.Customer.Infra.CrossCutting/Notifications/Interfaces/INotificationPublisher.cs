using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces
{
    public interface INotificationPublisher
    {
        Task PublishNotificationAsync(Notification notification, CancellationToken cancellationToken);
    }
}
