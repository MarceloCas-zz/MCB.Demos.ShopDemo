using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;

public class CustomerAddress
    : DomainEntityBase
{
    // Properties
    public CustomerAddressType CustomerAddressType { get; private set; }
    public AddressValueObject AddressValueObject { get; private set; }

    // Validators
    private readonly IRegisterNewCustomerAddressValidator _registerNewCustomerAddressValidator;

    // Constructors
    public CustomerAddress(
        IRegisterNewCustomerAddressValidator registerNewCustomerAddressValidator
    )
    {
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
        // TODO: Add validation

        // Process
        return SetCustomerAddressType(input.CustomerAddressType)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerAddress(ChangeCustomerAddressInput input)
    {
        // Validate
        // TODO: Add validation

        // Process and return
        return SetAddress(input.AddressValueObject)
            .RegisterModificationInternal<CustomerAddress>(input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeCustomerFullAddressInfo(ChangeCustomerFullAddressInfoInput input)
    {
        // Validate
        // TODO: Add validation

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
