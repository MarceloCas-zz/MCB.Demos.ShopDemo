using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models.Enums;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Notifications.Models;

public record Notification
{
    // Properties
    public NotificationType NotificationTypeMyProperty { get; }
    public string Code { get; }
    public string Description { get; }

    // Constructors
    public Notification(NotificationType notificationType, string code, string description)
    {
        NotificationTypeMyProperty = notificationType;
        Code = code;
        Description = description;
    }

}
