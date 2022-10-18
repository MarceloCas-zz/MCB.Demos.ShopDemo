using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories;

public sealed class CustomerAddressFactory
    : ICustomerAddressFactory
{
    // Fields
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IChangeCustomerAddressTypeInputShouldBeValidValidator _changeCustomerAddressTypeValidator;
    private readonly IChangeCustomerAddressInputShouldBeValidValidator _changeCustomerAddressValidator;
    private readonly IChangeCustomerFullAddressInfoInputShouldBeValidValidator _changeCustomerFullAddressInfoValidator;
    private readonly IRegisterNewCustomerAddressInputShouldBeValidValidator _registerNewCustomerAddressValidator;
    private readonly IAddressValueObjectShouldBeValidValidator _addressValueObjectShouldBeValidValidator;

    // Constructors
    public CustomerAddressFactory(
        IDateTimeProvider dateTimeProvider,
        IChangeCustomerAddressTypeInputShouldBeValidValidator changeCustomerAddressTypeValidator,
        IChangeCustomerAddressInputShouldBeValidValidator changeCustomerAddressValidator,
        IChangeCustomerFullAddressInfoInputShouldBeValidValidator changeCustomerFullAddressInfoValidator,
        IRegisterNewCustomerAddressInputShouldBeValidValidator registerNewCustomerAddressValidator,
        IAddressValueObjectShouldBeValidValidator addressValueObjectShouldBeValidValidator
    )
    {
        _dateTimeProvider = dateTimeProvider;
        _changeCustomerAddressTypeValidator = changeCustomerAddressTypeValidator;
        _changeCustomerAddressValidator = changeCustomerAddressValidator;
        _changeCustomerFullAddressInfoValidator = changeCustomerFullAddressInfoValidator;
        _registerNewCustomerAddressValidator = registerNewCustomerAddressValidator;
        _addressValueObjectShouldBeValidValidator = addressValueObjectShouldBeValidValidator;
    }

    // Public Methods
    public CustomerAddress Create()
    {
        return new CustomerAddress(
            _dateTimeProvider,
            _changeCustomerAddressTypeValidator,
            _changeCustomerAddressValidator,
            _changeCustomerFullAddressInfoValidator,
            _registerNewCustomerAddressValidator,
            _addressValueObjectShouldBeValidValidator
        );
    }
}