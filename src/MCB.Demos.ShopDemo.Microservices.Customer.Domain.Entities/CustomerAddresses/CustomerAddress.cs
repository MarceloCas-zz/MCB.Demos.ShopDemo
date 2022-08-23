using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

public class CustomerAddress
    : DomainEntityBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; private set; }
    public AddressValueObject AddressValueObject { get; private set; }

    // Validators
    private readonly IChangeCustomerAddressTypeValidator _changeCustomerAddressTypeValidator;
    private readonly IChangeCustomerAddressValidator _changeCustomerAddressValidator;
    private readonly IChangeCustomerFullAddressInfoValidator _changeCustomerFullAddressInfoValidator;
    private readonly IRegisterNewCustomerAddressValidator _registerNewCustomerAddressValidator;

    // Constructors
    public CustomerAddress(
        IChangeCustomerAddressTypeValidator changeCustomerAddressTypeValidator,
        IChangeCustomerAddressValidator changeCustomerAddressValidator,
        IChangeCustomerFullAddressInfoValidator changeCustomerFullAddressInfoValidator,
        IRegisterNewCustomerAddressValidator registerNewCustomerAddressValidator
    )
    {
        _changeCustomerAddressTypeValidator = changeCustomerAddressTypeValidator;
        _changeCustomerAddressValidator = changeCustomerAddressValidator;
        _changeCustomerFullAddressInfoValidator = changeCustomerFullAddressInfoValidator;
        _registerNewCustomerAddressValidator = registerNewCustomerAddressValidator;
    }

    // Public Methods
    public CustomerAddress RegisterNewCustomerAddress(RegisterNewCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _registerNewCustomerAddressValidator.Validate(input)))
            return this;

        // Process
        return RegisterNewInternal<CustomerAddress>(input.TenantId, input.ExecutionUser, input.SourcePlatform)
            .SetCustomerAddressType(input.CustomerAddressType)
            .SetAddress(input.AddressValueObject);
    }
    public CustomerAddress ChangeCustomerAddressType(ChangeCustomerAddressTypeInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressTypeValidator.Validate(input)))
            return this;

        // Process
        return SetCustomerAddressType(input.CustomerAddressType)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerAddress(ChangeCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressValidator.Validate(input)))
            return this;

        // Process and return
        return SetAddress(input.AddressValueObject)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerFullAddressInfo(ChangeCustomerFullAddressInfoInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerFullAddressInfoValidator.Validate(input)))
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
        _changeCustomerAddressTypeValidator,
        _changeCustomerAddressValidator,
        _changeCustomerFullAddressInfoValidator,
        _registerNewCustomerAddressValidator
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
