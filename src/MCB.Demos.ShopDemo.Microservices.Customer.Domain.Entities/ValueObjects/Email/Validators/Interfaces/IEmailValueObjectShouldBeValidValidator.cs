using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Interfaces;

public interface IEmailValueObjectShouldBeValidValidator
    : IValidator<EmailValueObject>
{
}