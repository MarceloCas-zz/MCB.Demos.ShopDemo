using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;

public interface INotificationSubscriber
    : ISubscriber<Notification>
{
    IEnumerable<Notification> NotificationCollection { get; }
}
