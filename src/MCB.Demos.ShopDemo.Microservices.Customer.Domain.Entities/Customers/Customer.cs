using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Email.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers;

public sealed class Customer
    : DomainEntityBase,
    IAggregationRoot
{
    // Fields
    private CustomerAddressInfo _customerAddressInfo;

    // Properties
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public EmailValueObject Email { get; private set; }

    // Navigation Properties
    public CustomerAddressInfo CustomerAddressInfo => _customerAddressInfo.DeepClone();

    // Validators
    private readonly IRegisterNewCustomerInputShouldBeValidValidator _customerCustomerRegisterNewInputShouldBeValidValidator;
    private readonly IChangeCustomerNameInputShouldBeValidValidator _changeCustomerNameInputShouldBeValidValidator;
    private readonly IChangeCustomerBirthDateInputShouldBeValidValidator _changeCustomerBirthDateInputShouldBeValidValidator;
    private readonly IAddNewCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerDefaultShippingAddressInputShouldBeValidValidator _changeCustomerDefaultShippingAddressInputShouldBeValidValidator;
    private readonly IClearCustomerDefaultShippingAddressInputShouldBeValidValidator _clearCustomerDefaultShippingAddressInputShouldBeValidValidator;
    private readonly IRemoveCustomerAddressInputShouldBeValidValidator _removeCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerAddressInputShouldBeValidValidator _changeCustomerAddressInputShouldBeValidValidator;
    private readonly IEmailValueObjectShouldBeValidValidator _emailValueObjectShouldBeValidValidator;

    // Factories
    private readonly ICustomerAddressInfoFactory _customerAddressInfoFactory;
    private readonly IChangeDefaultCustomerAddressInfoShippingAddressInputFactory _changeDefaultCustomerAddressInfoShippingAddressInputFactory;
    private readonly IClearDefaultCustomerAddressInfoShippingAddressInputFactory _clearDefaultCustomerAddressInfoShippingAddressInputFactory;
    private readonly IAddNewCustomerAddressInfoCustomerAddressInputFactory _addNewCustomerAddressInfoCustomerAddressInputFactory;
    private readonly IRemoveCustomerAddressInfoCustomerAddressInputFactory _removeCustomerAddressInfoCustomerAddressInputFactory;
    private readonly IChangeCustomerAddressInfoCustomerAddressInputFactory _changeCustomerAddressInfoCustomerAddressInputFactory;

    // Constructors
    public Customer(
        IDateTimeProvider dateTimeProvider,
        IRegisterNewCustomerInputShouldBeValidValidator customerRegisterNewInputShouldBeValidValidator,
        IChangeCustomerNameInputShouldBeValidValidator changeCustomerNameInputShouldBeValidValidator,
        IChangeCustomerBirthDateInputShouldBeValidValidator changeCustomerBirthDateInputShouldBeValidValidator,
        IAddNewCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerDefaultShippingAddressInputShouldBeValidValidator changeCustomerDefaultShippingAddressInputShouldBeValidValidator,
        IClearCustomerDefaultShippingAddressInputShouldBeValidValidator clearCustomerDefaultShippingAddressInputShouldBeValidValidator,
        IRemoveCustomerAddressInputShouldBeValidValidator removeCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerAddressInputShouldBeValidValidator changeCustomerAddressInputShouldBeValidValidator,
        IEmailValueObjectShouldBeValidValidator emailValueObjectShouldBeValidValidator,
        ICustomerAddressInfoFactory customerAddressInfoFactory,
        IChangeDefaultCustomerAddressInfoShippingAddressInputFactory changeDefaultCustomerAddressInfoShippingAddressInputFactory,
        IClearDefaultCustomerAddressInfoShippingAddressInputFactory clearDefaultCustomerAddressInfoShippingAddressInputFactory,
        IAddNewCustomerAddressInfoCustomerAddressInputFactory addNewCustomerAddressInfoCustomerAddressInputFactory,
        IRemoveCustomerAddressInfoCustomerAddressInputFactory removeCustomerAddressInfoCustomerAddressInputFactory,
        IChangeCustomerAddressInfoCustomerAddressInputFactory changeCustomerAddressInfoCustomerAddressInputFactory
    ) : base(dateTimeProvider)
    {
        FirstName = string.Empty;
        LastName = string.Empty;

        _customerCustomerRegisterNewInputShouldBeValidValidator = customerRegisterNewInputShouldBeValidValidator;
        _changeCustomerNameInputShouldBeValidValidator = changeCustomerNameInputShouldBeValidValidator;
        _changeCustomerBirthDateInputShouldBeValidValidator = changeCustomerBirthDateInputShouldBeValidValidator;
        _addNewCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInputShouldBeValidValidator;
        _changeCustomerDefaultShippingAddressInputShouldBeValidValidator = changeCustomerDefaultShippingAddressInputShouldBeValidValidator;
        _clearCustomerDefaultShippingAddressInputShouldBeValidValidator = clearCustomerDefaultShippingAddressInputShouldBeValidValidator;
        _removeCustomerAddressInputShouldBeValidValidator = removeCustomerAddressInputShouldBeValidValidator;
        _changeCustomerAddressInputShouldBeValidValidator = changeCustomerAddressInputShouldBeValidValidator;
        _emailValueObjectShouldBeValidValidator = emailValueObjectShouldBeValidValidator;

        _customerAddressInfoFactory = customerAddressInfoFactory;
        _changeDefaultCustomerAddressInfoShippingAddressInputFactory = changeDefaultCustomerAddressInfoShippingAddressInputFactory;
        _clearDefaultCustomerAddressInfoShippingAddressInputFactory = clearDefaultCustomerAddressInfoShippingAddressInputFactory;
        _addNewCustomerAddressInfoCustomerAddressInputFactory = addNewCustomerAddressInfoCustomerAddressInputFactory;
        _removeCustomerAddressInfoCustomerAddressInputFactory = removeCustomerAddressInfoCustomerAddressInputFactory;
        _changeCustomerAddressInfoCustomerAddressInputFactory = changeCustomerAddressInfoCustomerAddressInputFactory;

        _customerAddressInfo = customerAddressInfoFactory.Create();
    }

    // Public Methods
    public Customer RegisterNewCustomer(RegisterNewCustomerInput input)
    {
        // Validate
        if (!Validate(() => _customerCustomerRegisterNewInputShouldBeValidValidator.Validate(input)) ||
            !Validate(() => _emailValueObjectShouldBeValidValidator.Validate(input.Email)))
            return this;

        // Process and Return
        return SetName(input.FirstName, input.LastName)
            .SetBirthDate(input.BirthDate)
            .SetEmail(input.Email)
            .RegisterNewInternal<Customer>(input.TenantId, input.ExecutionUser, input.SourcePlatform);
    }
    public Customer ChangeCustomerName(ChangeCustomerNameInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerNameInputShouldBeValidValidator.Validate(input)))
            return this;

        // Process and Return
        return SetName(input.FirstName, input.LastName)
            .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
    }
    public Customer ChangeBirthDate(ChangeCustomerBirthDateInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerBirthDateInputShouldBeValidValidator.Validate(input)))
            return this;

        // Process and Return
        return SetBirthDate(input.BirthDate)
            .RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);
    }

    public CustomerAddress ChangeDefaultShippingAddress(ChangeCustomerDefaultShippingAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerDefaultShippingAddressInputShouldBeValidValidator.Validate(input)))
            return default;

        // Process
        var newDefaultShippingAddress = _customerAddressInfo.ChangeDefaultCustomerAddressInfoShippingAddress(
            _changeDefaultCustomerAddressInfoShippingAddressInputFactory.Create(input)
        );
        RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return newDefaultShippingAddress;
    }
    public Customer ClearDefaultShippingAddress(ClearCustomerDefaultShippingAddressInput input)
    {
        // Validate
        if (!Validate(() => _clearCustomerDefaultShippingAddressInputShouldBeValidValidator.Validate(input)))
            return default;

        // Process
        _customerAddressInfo.ClearDefaultCustomerAddressInfoShippingAddress(
            _clearDefaultCustomerAddressInfoShippingAddressInputFactory.Create(input)
        );
        RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return this;
    }

    public CustomerAddress AddNewCustomerAddress(AddNewCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _addNewCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return default;

        // Process Customer Address
        var addedCustomerAddress = _customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(
            _addNewCustomerAddressInfoCustomerAddressInputFactory.Create(input)
        );

        // Validate After Customer Address Process
        if (!addedCustomerAddress.ValidationInfo.IsValid)
        {
            AddFromValidationInfoInternal(addedCustomerAddress.ValidationInfo);
            return null;
        }

        // Process Customer
        RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return addedCustomerAddress;
    }
    public CustomerAddress RemoveCustomerAddress(RemoveCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _removeCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return default;

        // Process
        var removedCustomerAddress = _customerAddressInfo.RemoveCustomerAddressInfoCustomerAddress(
            _removeCustomerAddressInfoCustomerAddressInputFactory.Create(input)
        );
        RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return removedCustomerAddress;
    }
    public CustomerAddress ChangeCustomerAddress(ChangeCustomerAddressInput input)
    {
        // Validate
        if (!Validate(() => _changeCustomerAddressInputShouldBeValidValidator.Validate(input)))
            return default;

        // Process
        var changedCustomerAddress = _customerAddressInfo.ChangeCustomerAddressInfoCustomerAddress(
            _changeCustomerAddressInfoCustomerAddressInputFactory.Create(input)
        );
        RegisterModificationInternal<Customer>(input.ExecutionUser, input.SourcePlatform);

        // Return
        return changedCustomerAddress;
    }

    public Customer DeepClone()
    {
        // Process and Return
        return DeepCloneInternal<Customer>()
            .SetName(FirstName, LastName)
            .SetBirthDate(BirthDate)
            .SetCustomerAddressInfo(CustomerAddressInfo);
    }

    // Protected Abstract Methods
    protected override DomainEntityBase CreateInstanceForCloneInternal() =>
        new Customer(
            DateTimeProvider,
            _customerCustomerRegisterNewInputShouldBeValidValidator,
            _changeCustomerNameInputShouldBeValidValidator,
            _changeCustomerBirthDateInputShouldBeValidValidator,
            _addNewCustomerAddressInputShouldBeValidValidator,
            _changeCustomerDefaultShippingAddressInputShouldBeValidValidator,
            _clearCustomerDefaultShippingAddressInputShouldBeValidValidator,
            _removeCustomerAddressInputShouldBeValidValidator,
            _changeCustomerAddressInputShouldBeValidValidator,
            _emailValueObjectShouldBeValidValidator,
            _customerAddressInfoFactory,
            _changeDefaultCustomerAddressInfoShippingAddressInputFactory,
            _clearDefaultCustomerAddressInfoShippingAddressInputFactory,
            _addNewCustomerAddressInfoCustomerAddressInputFactory,
            _removeCustomerAddressInfoCustomerAddressInputFactory,
            _changeCustomerAddressInfoCustomerAddressInputFactory
        );

    // Private Methods
    private Customer SetName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        return this;
    }
    private Customer SetBirthDate(DateOnly birthDate)
    {
        BirthDate = birthDate;

        return this;
    }
    private Customer SetCustomerAddressInfo(CustomerAddressInfo customerAddressInfo)
    {
        _customerAddressInfo = customerAddressInfo;
        return this;
    }
    private Customer SetEmail(string email)
    {
        Email = email;
        return this;
    }
}