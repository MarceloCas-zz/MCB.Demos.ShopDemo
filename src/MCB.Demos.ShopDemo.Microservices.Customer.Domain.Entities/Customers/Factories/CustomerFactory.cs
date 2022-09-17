using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories;

public sealed class CustomerFactory
    : ICustomerFactory
{
    // Fields
    private readonly IRegisterNewCustomerInputShouldBeValidValidator _customerRegisterNewInputShouldBeValidValidator;
    private readonly IChangeCustomerNameInputShouldBeValidValidator _changeCustomerNameInputShouldBeValidValidator;
    private readonly IChangeCustomerBirthDateInputShouldBeValidValidator _changeCustomerBirthDateInputShouldBeValidValidator;
    private readonly IAddNewCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerDefaultShippingAddressInputShouldBeValidValidator _changeCustomerDefaultShippingAddressInputShouldBeValidValidator;
    private readonly IClearCustomerDefaultShippingAddressInputShouldBeValidValidator _clearCustomerDefaultShippingAddressInputShouldBeValidValidator;
    private readonly IRemoveCustomerAddressInputShouldBeValidValidator _removeCustomerAddressInputShouldBeValidValidator;
    private readonly IChangeCustomerAddressInputShouldBeValidValidator _changeCustomerAddressInputShouldBeValidValidator;

    private readonly ICustomerAddressInfoFactory _customerAddressInfoFactory;
    private readonly IChangeDefaultCustomerAddressInfoShippingAddressInputFactory _changeDefaultCustomerAddressInfoShippingAddressInputFactory;
    private readonly IClearDefaultCustomerAddressInfoShippingAddressInputFactory _clearDefaultCustomerAddressInfoShippingAddressInputFactory;
    private readonly IAddNewCustomerAddressInfoCustomerAddressInputFactory _addNewCustomerAddressInfoCustomerAddressInputFactory;
    private readonly IRemoveCustomerAddressInfoCustomerAddressInputFactory _removeCustomerAddressInfoCustomerAddressInputFactory;
    private readonly IChangeCustomerAddressInfoCustomerAddressInputFactory _changeCustomerAddressInfoCustomerAddressInputFactory;

    // Constructors
    public CustomerFactory(
        IRegisterNewCustomerInputShouldBeValidValidator customerRegisterNewInputShouldBeValidValidator,
        IChangeCustomerNameInputShouldBeValidValidator changeCustomerNameInputShouldBeValidValidator,
        IChangeCustomerBirthDateInputShouldBeValidValidator changeCustomerBirthDateInputShouldBeValidValidator,
        IAddNewCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerDefaultShippingAddressInputShouldBeValidValidator changeCustomerDefaultShippingAddressInputShouldBeValidValidator,
        IClearCustomerDefaultShippingAddressInputShouldBeValidValidator clearCustomerDefaultShippingAddressInputShouldBeValidValidator,
        IRemoveCustomerAddressInputShouldBeValidValidator removeCustomerAddressInputShouldBeValidValidator,
        IChangeCustomerAddressInputShouldBeValidValidator changeCustomerAddressInputShouldBeValidValidator,
        ICustomerAddressInfoFactory customerAddressInfoFactory,
        IChangeDefaultCustomerAddressInfoShippingAddressInputFactory changeDefaultCustomerAddressInfoShippingAddressInputFactory,
        IClearDefaultCustomerAddressInfoShippingAddressInputFactory clearDefaultCustomerAddressInfoShippingAddressInputFactory,
        IAddNewCustomerAddressInfoCustomerAddressInputFactory addNewCustomerAddressInfoCustomerAddressInputFactory,
        IRemoveCustomerAddressInfoCustomerAddressInputFactory removeCustomerAddressInfoCustomerAddressInputFactory,
        IChangeCustomerAddressInfoCustomerAddressInputFactory changeCustomerAddressInfoCustomerAddressInputFactory
    )
    {
        _customerRegisterNewInputShouldBeValidValidator = customerRegisterNewInputShouldBeValidValidator;
        _changeCustomerNameInputShouldBeValidValidator = changeCustomerNameInputShouldBeValidValidator;
        _changeCustomerBirthDateInputShouldBeValidValidator = changeCustomerBirthDateInputShouldBeValidValidator;
        _addNewCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInputShouldBeValidValidator;
        _changeCustomerDefaultShippingAddressInputShouldBeValidValidator = changeCustomerDefaultShippingAddressInputShouldBeValidValidator;
        _clearCustomerDefaultShippingAddressInputShouldBeValidValidator = clearCustomerDefaultShippingAddressInputShouldBeValidValidator;
        _removeCustomerAddressInputShouldBeValidValidator = removeCustomerAddressInputShouldBeValidValidator;
        _changeCustomerAddressInputShouldBeValidValidator = changeCustomerAddressInputShouldBeValidValidator;

        _customerAddressInfoFactory = customerAddressInfoFactory;
        _changeDefaultCustomerAddressInfoShippingAddressInputFactory = changeDefaultCustomerAddressInfoShippingAddressInputFactory;
        _clearDefaultCustomerAddressInfoShippingAddressInputFactory = clearDefaultCustomerAddressInfoShippingAddressInputFactory;
        _addNewCustomerAddressInfoCustomerAddressInputFactory = addNewCustomerAddressInfoCustomerAddressInputFactory;
        _removeCustomerAddressInfoCustomerAddressInputFactory = removeCustomerAddressInfoCustomerAddressInputFactory;
        _changeCustomerAddressInfoCustomerAddressInputFactory = changeCustomerAddressInfoCustomerAddressInputFactory;
    }

    // Public Methods
    public Customer Create()
    {
        return new Customer(
            _customerRegisterNewInputShouldBeValidValidator,
            _changeCustomerNameInputShouldBeValidValidator,
            _changeCustomerBirthDateInputShouldBeValidValidator,
            _addNewCustomerAddressInputShouldBeValidValidator,
            _changeCustomerDefaultShippingAddressInputShouldBeValidValidator,
            _clearCustomerDefaultShippingAddressInputShouldBeValidValidator,
            _removeCustomerAddressInputShouldBeValidValidator,
            _changeCustomerAddressInputShouldBeValidValidator,
            _customerAddressInfoFactory,
            _changeDefaultCustomerAddressInfoShippingAddressInputFactory,
            _clearDefaultCustomerAddressInfoShippingAddressInputFactory,
            _addNewCustomerAddressInfoCustomerAddressInputFactory,
            _removeCustomerAddressInfoCustomerAddressInputFactory,
            _changeCustomerAddressInfoCustomerAddressInputFactory
        );
    }
}
