using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Observer;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Observer;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications;

internal class NotificationPublisherInternal
    : PublisherBase,
    INotificationPublisherInternal
{
    // Constants
    public const string SUBSCRIBER_TYPE_CANNOT_INSTANCIATED_MESSAGE = "SubscriberType cannot instanciated [{0}]";

    // Fields
    private readonly IDependencyInjectionContainer _dependencyInjectionContainer;

    // Constructors
    public NotificationPublisherInternal(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        _dependencyInjectionContainer = dependencyInjectionContainer;
    }

    protected override ISubscriber<TSubject> InstanciateSubscriber<TSubject>(Type subscriberType)
    {
        var instance = _dependencyInjectionContainer.Resolve(subscriberType);

        if (instance is null)
            throw new InvalidOperationException(string.Format(SUBSCRIBER_TYPE_CANNOT_INSTANCIATED_MESSAGE, subscriberType.FullName));

        return (ISubscriber<TSubject>)instance;
    }
}
