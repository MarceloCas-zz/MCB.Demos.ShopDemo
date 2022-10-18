using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo;

public sealed class CustomerAddressInfo
    : DomainEntityBase
{
    // Fields
    private readonly List<CustomerAddress> _customerAddressCollection = new();
    private CustomerAddress _defaultShippingAddress;

    // Properties
    public IEnumerable<CustomerAddress> CustomerAddressCollection => _customerAddressCollection.AsReadOnly().Select(q => q.DeepClone());
    public CustomerAddress DefaultShippingAddress => _defaultShippingAddress?.DeepClone();

    // Factories
    private readonly ICustomerAddressFactory _customerAddressFactory;
    private readonly IRegisterNewCustomerAddressInputFactory _registerNewCustomerAddressInputFactory;
    private readonly IChangeCustomerFullAddressInfoInputFactory _changeCustomerFullAddressInfoInputFactory;

    // Validators
    private readonly IRegisterNewCustomerAddressInfoInputShouldBeValidValidator _registerNewCustomerAddressInfoInputShouldBeValidValidator;
    private readonly IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
    private readonly IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
    private readonly IAddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
    private readonly ICustomerAddressInfoShouldHaveCustomerAddressValidator _customerAddressInfoShouldHaveCustomerAddressValidator;
    private readonly IRemoveCustomerAddressInfoCustomerAddressInputShouldBeValidValidator _removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator _changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;

    // Constructors
    public CustomerAddressInfo(
        IDateTimeProvider dateTimeProvider,
        ICustomerAddressFactory customerAddressFactory,
        IRegisterNewCustomerAddressInputFactory registerNewCustomerAddressInputShouldBeValidFactory,
        IChangeCustomerFullAddressInfoInputFactory changeCustomerFullAddressInfoInputFactory,
        IRegisterNewCustomerAddressInfoInputShouldBeValidValidator registerNewCustomerAddressInfoInputShouldBeValidValidator,
        IChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
        IClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
        IAddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator,
        ICustomerAddressInfoShouldHaveCustomerAddressValidator customerAddressInfoShouldHaveCustomerAddressValidator,
        IRemoveCustomerAddressInfoCustomerAddressInputShouldBeValidValidator removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator
    ) : base(dateTimeProvider)
    {
        _customerAddressFactory = customerAddressFactory;
        _registerNewCustomerAddressInputFactory = registerNewCustomerAddressInputShouldBeValidFactory;
        _changeCustomerFullAddressInfoInputFactory = changeCustomerFullAddressInfoInputFactory;
        _registerNewCustomerAddressInfoInputShouldBeValidValidator = registerNewCustomerAddressInfoInputShouldBeValidValidator;
        _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator = changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
        _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator = clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator;
        _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
        _customerAddressInfoShouldHaveCustomerAddressValidator = customerAddressInfoShouldHaveCustomerAddressValidator;
        _removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator = removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
        _changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator = changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator;
    }

    // Public Methods
    public CustomerAddressInfo RegisterNewCustomerAddressInfo(RegisterNewCustomerAddressInfoInput input)
    {
        // Validate input
        if (!Validate(() => _registerNewCustomerAddressInfoInputShouldBeValidValidator.Validate(input)))
            return this;

        // Register new customer address
        var customerAddress =
            _customerAddressFactory
            .Create()
            .RegisterNewCustomerAddress(_registerNewCustomerAddressInputFactory.Create(input));

        if (!Validate(() => customerAddress.ValidationInfo))
            return this;

        // Process
        AddCustomerAddress(customerAddress);

        if (!ValidationInfo.IsValid)
            return this;

        if (input.IsDefaultShippingAddress)
            SetDefaultShippingAddress(customerAddress);

        // Return
        return RegisterNewInternal<CustomerAddressInfo>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
    }
    public CustomerAddress ChangeDefaultCustomerAddressInfoShippingAddress(ChangeDefaultCustomerAddressInfoShippingAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator.Validate(input)))
            return null;
        if (!Validate(() => _customerAddressInfoShouldHaveCustomerAddressValidator.Validate((input.CustomerAddressId, _customerAddressCollection.AsEnumerable()))))
            return null;

        // Process
        var existingCustomerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);
        SetDefaultShippingAddress(existingCustomerAddress)
            .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return DefaultShippingAddress;
    }
    public CustomerAddressInfo ClearDefaultCustomerAddressInfoShippingAddress(ClearDefaultCustomerAddressInfoShippingAddressInput input)
    {
        // Validate
        if (!Validate(() => _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator.Validate(input)))
            return this;

        // Process and Return
        return SetDefaultShippingAddress(customerAddress: null)
            .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);
    }

    public CustomerAddress AddNewCustomerAddressInfoCustomerAddress(AddNewCustomerAddressInfoCustomerAddressInput input)
    {
        // Validate input
        if (!Validate(() => _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return null;

        // Register new customer address
        var customerAddress =
            _customerAddressFactory
            .Create()
            .RegisterNewCustomerAddress(_registerNewCustomerAddressInputFactory.Create(input));

        if (!Validate(() => customerAddress.ValidationInfo))
            return null;

        // Process
        AddCustomerAddress(customerAddress)
            .RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

        if (!ValidationInfo.IsValid)
            return null;

        // Return
        return customerAddress;
    }
    public CustomerAddress RemoveCustomerAddressInfoCustomerAddress(RemoveCustomerAddressInfoCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return null;
        if (!Validate(() => _customerAddressInfoShouldHaveCustomerAddressValidator.Validate((input.CustomerAddressId, _customerAddressCollection.AsEnumerable()))))
            return null;

        // Process
        var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);
        if (customerAddress is null)
            return null;

        _customerAddressCollection.Remove(
            customerAddress
        );
        RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return customerAddress;
    }
    public CustomerAddress ChangeCustomerAddressInfoCustomerAddress(ChangeCustomerAddressInfoCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return null;
        if (!Validate(() => _customerAddressInfoShouldHaveCustomerAddressValidator.Validate((input.CustomerAddressId, _customerAddressCollection.AsEnumerable()))))
            return null;

        var customerAddress = _customerAddressCollection.FirstOrDefault(q => q.Id == input.CustomerAddressId);

        // Process
        customerAddress.ChangeCustomerFullAddressInfo(_changeCustomerFullAddressInfoInputFactory.Create(input));
        RegisterModificationInternal<CustomerAddressInfo>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return customerAddress;
    }

    public CustomerAddressInfo DeepClone()
    {
        // Process
        var customerAddressInfo = DeepCloneInternal<CustomerAddressInfo>()
            .SetCustomerAddressCollection(CustomerAddressCollection);

        if (_defaultShippingAddress != null)
            customerAddressInfo.SetDefaultShippingAddress(DefaultShippingAddress);

        // Return
        return customerAddressInfo;
    }

    // Private Methods
    private CustomerAddressInfo AddCustomerAddress(CustomerAddress customerAddress)
    {
        _customerAddressCollection.Add(customerAddress);
        return this;
    }
    private CustomerAddressInfo SetCustomerAddressCollection(IEnumerable<CustomerAddress> customerAddressCollection)
    {
        // Process
        _customerAddressCollection.Clear();
        _customerAddressCollection.AddRange(customerAddressCollection);

        // Return
        return this;
    }
    private CustomerAddressInfo SetDefaultShippingAddress(CustomerAddress customerAddress)
    {
        _defaultShippingAddress = customerAddress;
        return this;
    }

    // Protected Methods
    protected override DomainEntityBase CreateInstanceForCloneInternal() => new CustomerAddressInfo(
        DateTimeProvider,
        _customerAddressFactory,
        _registerNewCustomerAddressInputFactory,
        _changeCustomerFullAddressInfoInputFactory,
        _registerNewCustomerAddressInfoInputShouldBeValidValidator,
        _changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
        _clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator,
        _addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator,
        _customerAddressInfoShouldHaveCustomerAddressValidator,
        _removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator,
        _changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator
    );
}