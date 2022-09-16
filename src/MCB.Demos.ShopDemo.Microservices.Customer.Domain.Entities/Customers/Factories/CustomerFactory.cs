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
        ICustomerAddressInfoFactory customerAddressInfoFactory
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
            _customerAddressInfoFactory
        );
    }
}
