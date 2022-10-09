using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;
using System.Collections.Concurrent;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications;

internal class NotificationSubscriber
    : INotificationSubscriber
{
    // Fields
    private readonly ConcurrentQueue<Notification> _notificationCollection;

    // Properties
    public IEnumerable<Notification> NotificationCollection => _notificationCollection.AsEnumerable();

    // Constructors
    internal NotificationSubscriber()
    {
        _notificationCollection = new ConcurrentQueue<Notification>();
    }

    // Public Methods
    public Task HandlerAsync(Notification subject, CancellationToken cancellationToken)
    {
        _notificationCollection.Enqueue(subject);
        return Task.CompletedTask;
    }
}
