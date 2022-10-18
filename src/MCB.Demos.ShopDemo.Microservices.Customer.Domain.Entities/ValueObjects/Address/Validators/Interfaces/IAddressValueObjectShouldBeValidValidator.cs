using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Interfaces;

public interface IAddressValueObjectShouldBeValidValidator
    : IValidator<AddressValueObject>
{
}