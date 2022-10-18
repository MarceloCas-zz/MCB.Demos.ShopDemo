using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Events.CustomerHasBeenRegistered;

public record CustomerHasBeenRegisteredEvent
    : EventBase
{
    public CustomerDto? Customer { get; set; }
}