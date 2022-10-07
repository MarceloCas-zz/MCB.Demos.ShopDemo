using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications
{
    internal class NotificationPublisher
        : INotificationPublisher
    {
        // Fields
        private readonly INotificationPublisherInternal _notificationPublisherInternal;

        // Constructors
        internal NotificationPublisher(INotificationPublisherInternal notificationPublisherInternal)
        {
            _notificationPublisherInternal = notificationPublisherInternal;
        }

        // Public Methods
        public Task PublishNotificationAsync(Notification notification, CancellationToken cancellationToken)
        {
            return _notificationPublisherInternal.PublishAsync(notification, cancellationToken);
        }
    }
}
