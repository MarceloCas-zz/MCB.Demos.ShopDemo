using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using MCB.Tests;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.CustomersTests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerAddressTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public CustomerAddressTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CustomerAddress_Should_Correctly_Instanciated()
        {
            // Arrange and Act
            var customerAddress = new CustomerAddress(
                new ChangeCustomerAddressTypeValidator(new CustomerAddressSpecifications()),
                new ChangeCustomerAddressValidator(new CustomerAddressSpecifications()),
                new ChangeCustomerFullAddressInfoValidator(new CustomerAddressSpecifications()),
                new RegisterNewCustomerAddressValidator(new CustomerAddressSpecifications())
            );

            // Assert
            customerAddress.CustomerAddressType.Should().Be(default);
            customerAddress.AddressValueObject.Should().Be(default(AddressValueObject));
        }

        [Fact]
        public void CustomerAddress_Should_RegisterNew()
        {
            foreach (var customerAddressType in Enum.GetValues<CustomerAddressType>())
            {
                // Arrange
                var addressValueObject = DefaultFixture.GenerateNewAddressValueObject();

                // Act
                var customerAddress = DefaultFixture.GenerateNewCustomerAddress(
                    existingTenantId: _fixture.TenantId,
                    existingCustomerAdressType: customerAddressType,
                    existingCustomerAddress: addressValueObject,
                    existingExecutionUser: _fixture.ExecutionUser,
                    existingSourcePlatform: _fixture.SourcePlatform
                );

                // Assert
                ValidateAfterRegisterNew(customerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);
            }
        }

        [Fact]
        public void CustomerAddress_Should_ChangeCustomerAddressType()
        {
            // Arrange
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAdressType: CustomerAddressType.HomeAddress);
            GenerateNewDateForDateTimeProvider();
            var clonedCustomerAddressAfterNewRegistration = customerAddress.DeepClone();

            var newCustomerAddressType = CustomerAddressType.BusinessAddress;
            var initialCustomerAddressType = customerAddress.CustomerAddressType;

            // Act
            customerAddress.ChangeCustomerAddressType(new CustomerAddresses.Inputs.ChangeCustomerAddressTypeInput(
               _fixture.TenantId,
               newCustomerAddressType, 
               _fixture.ExecutionUser, 
               _fixture.SourcePlatform
            ));

            // Assert
            customerAddress.CustomerAddressType.Should().NotBe(initialCustomerAddressType);
            customerAddress.CustomerAddressType.Should().Be(newCustomerAddressType);
            ValidateAfterRegisterModification(clonedCustomerAddressAfterNewRegistration, customerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);
        }

        [Fact]
        public void CustomerAddress_Should_ChangeAddress()
        {
            // Arrange
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAddress: DefaultFixture.GenerateNewAddressValueObject());
            GenerateNewDateForDateTimeProvider();
            var clonedCustomerAddressAfterNewRegistration = customerAddress.DeepClone();

            var newCustomerAddress = DefaultFixture.GenerateNewAddressValueObject();

            var initialCustomerAddressType = customerAddress.CustomerAddressType;

            // Act
            customerAddress.ChangeCustomerAddress(new CustomerAddresses.Inputs.ChangeCustomerAddressInput(
                _fixture.TenantId,
                newCustomerAddress, 
                _fixture.ExecutionUser, 
                _fixture.SourcePlatform
            ));

            // Assert
            customerAddress.AddressValueObject.Should().NotBe(initialCustomerAddressType);
            customerAddress.AddressValueObject.Should().Be(newCustomerAddress);
            ValidateAfterRegisterModification(clonedCustomerAddressAfterNewRegistration, customerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);
        }

        [Fact]
        public void CustomerAddress_Should_ChangeFullAddressInfo()
        {
            // Arrange
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress(existingCustomerAddress: DefaultFixture.GenerateNewAddressValueObject(), existingCustomerAdressType: CustomerAddressType.HomeAddress);
            GenerateNewDateForDateTimeProvider();
            var clonedCustomerAddressAfterNewRegistration = customerAddress.DeepClone();

            var newCustomerAddress = DefaultFixture.GenerateNewAddressValueObject();
            var newCustomerAddressType = CustomerAddressType.BusinessAddress;
            var initialCustomerAddressType = customerAddress.CustomerAddressType;

            // Act
            customerAddress.ChangeCustomerFullAddressInfo(new CustomerAddresses.Inputs.ChangeCustomerFullAddressInfoInput(
                _fixture.TenantId,
                newCustomerAddressType, 
                newCustomerAddress, 
                _fixture.ExecutionUser, 
                _fixture.SourcePlatform
            ));

            // Assert
            customerAddress.AddressValueObject.Should().NotBe(initialCustomerAddressType);
            customerAddress.AddressValueObject.Should().Be(newCustomerAddress);
            customerAddress.CustomerAddressType.Should().NotBe(initialCustomerAddressType);
            customerAddress.CustomerAddressType.Should().Be(newCustomerAddressType);
            ValidateAfterRegisterModification(clonedCustomerAddressAfterNewRegistration, customerAddress, _fixture.ExecutionUser, _fixture.SourcePlatform);
        }

        [Fact]
        public void CustomerAddress_Should_DeepClone()
        {
            // Arrange
            var customerAddress = DefaultFixture.GenerateNewCustomerAddress();

            // Act
            var clonedCustomerAddress = customerAddress.DeepClone();

            // Assert
            customerAddress.Should().NotBeSameAs(clonedCustomerAddress);
            customerAddress.AuditableInfo.Should().NotBeSameAs(clonedCustomerAddress.AuditableInfo);
            DefaultFixture.CompareTwoCustomerAddressValues(clonedCustomerAddress, customerAddress).Should().BeTrue();
        }
    }
}