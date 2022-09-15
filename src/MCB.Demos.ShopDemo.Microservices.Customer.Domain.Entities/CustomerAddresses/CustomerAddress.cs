using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

public class CustomerAddress
    : DomainEntityBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; private set; }
    public AddressValueObject AddressValueObject { get; private set; }

    // Validators
    private readonly IChangeCustomerAddressTypeInputShouldBeValidValidator _changeCustomerAddressTypeInputShouldBeValidValidator;
    private readonly IChangeCustomerAddressInputShouldBeValidValidator _changeCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerFullAddressInfoInputShouldBeValidValidator _changeCustomerFullAddressInfoInputShouldBeValidValidator;
    private readonly IRegisterNewCustomerAddressInputShouldBeValidValidator _registerNewCustomerAddressInputShouldBeValidValidator;
    private readonly IAddressValueObjectShouldBeValidValidator _addressValueObjectShouldBeValidValidator;

    // Constructors
    public CustomerAddress(
        IChangeCustomerAddressTypeInputShouldBeValidValidator changeCustomerAddressTypeInputShouldBeValidValidator,
        IChangeCustomerAddressInputShouldBeValidValidator changeCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerFullAddressInfoInputShouldBeValidValidator changeCustomerFullAddressInfoInputShouldBeValidValidator,
        IRegisterNewCustomerAddressInputShouldBeValidValidator registerNewCustomerAddressInputShouldBeValidValidator,
        IAddressValueObjectShouldBeValidValidator addressValueObjectShouldBeValidValidator
    )
    {
        _changeCustomerAddressTypeInputShouldBeValidValidator = changeCustomerAddressTypeInputShouldBeValidValidator;
        _changeCustomerAddressInputShouldBeValidValidator = changeCustomerAddressInputShouldBeValidValidator;
        _changeCustomerFullAddressInfoInputShouldBeValidValidator = changeCustomerFullAddressInfoInputShouldBeValidValidator;
        _registerNewCustomerAddressInputShouldBeValidValidator = registerNewCustomerAddressInputShouldBeValidValidator;
        _addressValueObjectShouldBeValidValidator = addressValueObjectShouldBeValidValidator;
    }

    // Public Methods
    public CustomerAddress RegisterNewCustomerAddress(RegisterNewCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _registerNewCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return this;
        if (!Validate(() => _addressValueObjectShouldBeValidValidator.Validate(input.AddressValueObject)))
            return this;

        // Process
        return RegisterNewInternal<CustomerAddress>(input.TenantId, input.ExecutionUser, input.SourcePlatform)
            .SetCustomerAddressType(input.CustomerAddressType)
            .SetAddress(input.AddressValueObject);
    }
    public CustomerAddress ChangeCustomerAddressType(ChangeCustomerAddressTypeInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressTypeInputShouldBeValidValidator.Validate(input)))
            return this;

        // Process
        return SetCustomerAddressType(input.CustomerAddressType)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerAddress(ChangeCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return this;
        if (!Validate(() => _addressValueObjectShouldBeValidValidator.Validate(input.AddressValueObject)))
            return this;

        // Process and return
        return SetAddress(input.AddressValueObject)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerFullAddressInfo(ChangeCustomerFullAddressInfoInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerFullAddressInfoInputShouldBeValidValidator.Validate(input)))
            return this;
        if (!Validate(() => _addressValueObjectShouldBeValidValidator.Validate(input.AddressValueObject)))
            return this;

        // Process
        return SetCustomerAddressType(input.CustomerAddressType)
            .SetAddress(input.AddressValueObject)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }

    public CustomerAddress DeepClone()
    {
        // Process and Return
        return DeepCloneInternal<CustomerAddress>()
            .SetCustomerAddressType(CustomerAddressType)
            .SetAddress(AddressValueObject);
    }

    // Protected Abstract Methods
    protected override DomainEntityBase CreateInstanceForCloneInternal() => new CustomerAddress(
        _changeCustomerAddressTypeInputShouldBeValidValidator,
        _changeCustomerAddressInputShouldBeValidValidator,
        _changeCustomerFullAddressInfoInputShouldBeValidValidator,
        _registerNewCustomerAddressInputShouldBeValidValidator,
        _addressValueObjectShouldBeValidValidator
    );

    // Private Methods
    private CustomerAddress SetCustomerAddressType(CustomerAddressType customerAddressType)
    {
        CustomerAddressType = customerAddressType;
        return this;
    }
    private CustomerAddress SetAddress(AddressValueObject addressValueObject)
    {
        AddressValueObject = addressValueObject;
        return this;
    }
}
