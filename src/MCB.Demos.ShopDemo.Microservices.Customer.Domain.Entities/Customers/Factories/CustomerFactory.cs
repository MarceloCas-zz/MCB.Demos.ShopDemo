﻿using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Factories
{
    public class CustomerFactory
        : ICustomerFactory
    {
        // Fields
        private readonly IRegisterNewCustomerInputShouldBeValidValidator _customerRegisterNewInputShouldBeValidValidator;
        private readonly IChangeCustomerNameInputShouldBeValidValidator _changeCustomerNameInputShouldBeValidValidator;
        private readonly IChangeCustomerBirthDateInputShouldBeValidValidator _changeCustomerBirthDateInputShouldBeValidValidator;
        private readonly IAddNewCustomerAddressInputShouldBeValidValidator _addNewCustomerAddressInputShouldBeValidValidator;

        // Constructors
        public CustomerFactory(
            IRegisterNewCustomerInputShouldBeValidValidator customerRegisterNewInputShouldBeValidValidator,
            IChangeCustomerNameInputShouldBeValidValidator changeCustomerNameInputShouldBeValidValidator,
            IChangeCustomerBirthDateInputShouldBeValidValidator changeCustomerBirthDateInputShouldBeValidValidator,
            IAddNewCustomerAddressInputShouldBeValidValidator addNewCustomerAddressInputShouldBeValidValidator
        )
        {
            _customerRegisterNewInputShouldBeValidValidator = customerRegisterNewInputShouldBeValidValidator;
            _changeCustomerNameInputShouldBeValidValidator = changeCustomerNameInputShouldBeValidValidator;
            _changeCustomerBirthDateInputShouldBeValidValidator = changeCustomerBirthDateInputShouldBeValidValidator;
            _addNewCustomerAddressInputShouldBeValidValidator = addNewCustomerAddressInputShouldBeValidValidator;
        }

        // Public Methods
        public Customer Create()
        {
            return new Customer(
                _customerRegisterNewInputShouldBeValidValidator,
                _changeCustomerNameInputShouldBeValidValidator,
                _changeCustomerBirthDateInputShouldBeValidValidator,
                _addNewCustomerAddressInputShouldBeValidValidator
            );
        }
    }
}