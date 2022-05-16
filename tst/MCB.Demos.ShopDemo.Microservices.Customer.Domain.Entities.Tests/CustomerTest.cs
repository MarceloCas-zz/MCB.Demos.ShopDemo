using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests
{
    [Collection(nameof(DefaultFixture))]
    public class CustomerTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public CustomerTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Customer_Should_Correctly_Instanciated()
        {
            // Arrange and Act
            var customer = new Customer();

            // Assert
            customer.FirstName.Should().BeNullOrEmpty();
            customer.LastName.Should().BeNullOrEmpty();
            customer.BirthDate.Should().Be(default);
            customer.CustomerAddressInfo.Should().NotBeNull();
        }

        [Fact]
        public void Customer_Should_RegisterNew()
        {
            // Arrange
            var tenantId = _fixture.TenantId;
            var firstName = "Marcelo";
            var lastName = "Castelo Branco";
            var birthDate = DateOnly.FromDateTime(DateTimeProvider.GetDate().DateTime);
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            // Act
            var customer = new Customer().RegisterNew(
                tenantId,
                firstName,
                lastName,
                birthDate,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterNew(customer, executionUser, sourcePlatform);
            customer.TenantId.Should().Be(tenantId);
            customer.FirstName.Should().Be(firstName);
            customer.LastName.Should().Be(lastName);
            customer.BirthDate.Should().Be(birthDate);
        }

        [Fact]
        public void Customer_Should_ChangeName()
        {
            // Arrange
            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();
            GenerateNewDateForDateTimeProvider();
            var firstName = "Marcelo";
            var lastName = "Castelo Branco";
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            // Act
            customer.ChangeName(
                firstName,
                lastName,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);
            customer.FirstName.Should().Be(firstName);
            customer.LastName.Should().Be(lastName);
        }

        [Fact]
        public void Customer_Should_ChangeBirthDate()
        {
            // Arrange
            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();
            GenerateNewDateForDateTimeProvider();
            var birthDate = DateOnly.FromDateTime(DateTimeProvider.GetDate().AddYears(-21).DateTime);
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            // Act
            customer.ChangeBirthDate(
                birthDate,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);
            customer.BirthDate.Should().Be(birthDate);
        }

        [Fact]
        public void Customer_Should_ChangeDefaultShippingAddress()
        {
            // Arrange
            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();
            GenerateNewDateForDateTimeProvider();

            var newShippingAddress = DefaultFixture.GenerateNewCustomerAddress();
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;
            var originalCustomerAddress = customer.CustomerAddressInfo.DeepClone();

            var originalDefaultShippingAddress = customer.CustomerAddressInfo?.DefaultShippingAddress;

            // Act
            var newDefaultShippingAddress = customer.ChangeDefaultShippingAddress(
                newShippingAddress,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);

            customer.CustomerAddressInfo.Should().NotBeSameAs(customer.CustomerAddressInfo);
            originalCustomerAddress.Should().NotBeSameAs(customer.CustomerAddressInfo);

            originalDefaultShippingAddress.Should().BeNull();
            originalDefaultShippingAddress.Should().NotBeSameAs(customer.CustomerAddressInfo.DefaultShippingAddress);
            DefaultFixture.CompareTwoCustomerAddressValues(
                newDefaultShippingAddress,
                customer.CustomerAddressInfo.DefaultShippingAddress
            ).Should().BeTrue();
        }

        [Fact]
        public void Customer_Should_ClearDefaultShippingAddress()
        {
            // Arrange
            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();
            GenerateNewDateForDateTimeProvider();

            var newShippingAddress = DefaultFixture.GenerateNewCustomerAddress();
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            customer.ChangeDefaultShippingAddress(
                newShippingAddress,
                executionUser,
                sourcePlatform
            );
            var originalDefaultShippingAddress = customer.CustomerAddressInfo?.DefaultShippingAddress;

            // Act
            customer.ClearDefaultShippingAddress(executionUser, sourcePlatform);

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);
            originalDefaultShippingAddress.Should().NotBe(customer.CustomerAddressInfo.DefaultShippingAddress);
            customer.CustomerAddressInfo.DefaultShippingAddress.Should().BeNull();
        }

        [Fact]
        public void Customer_Should_AddNewCustomerAddress()
        {
            // Arrange
            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();
            GenerateNewDateForDateTimeProvider();

            var customerAddressType = CustomerAddressType.BusinessAddress;
            var addressValueObject = DefaultFixture.GenerateNewAddressValueObject();
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            // Act
            var addedCustomerAddress = customer.AddNewCustomerAddress(
                customerAddressType,
                addressValueObject,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);
            customer.CustomerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
            customer.CustomerAddressInfo.CustomerAddressCollection.Should().HaveCount(1);
            DefaultFixture.CompareTwoCustomerAddressValues(
                customer.CustomerAddressInfo.CustomerAddressCollection.First(),
                addedCustomerAddress
            ).Should().BeTrue();
        }

        [Fact]
        public void Customer_Should_RemoveCustomerAddress()
        {
            // Arrange
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();

            var newCustomerAddressValueObject1 = DefaultFixture.GenerateNewAddressValueObject();
            var newCustomerAddressValueObject2 = DefaultFixture.GenerateNewAddressValueObject();

            customer.AddNewCustomerAddress(CustomerAddressType.BusinessAddress, newCustomerAddressValueObject1, executionUser, sourcePlatform);
            customer.AddNewCustomerAddress(CustomerAddressType.BusinessAddress, newCustomerAddressValueObject2, executionUser, sourcePlatform);

            var customerAddressToRemove = customer.CustomerAddressInfo.CustomerAddressCollection.First();

            GenerateNewDateForDateTimeProvider();

            // Act
            var removedCustomerAddress = customer.RemoveCustomerAddress(
                customerAddressToRemove.Id, 
                executionUser, 
                sourcePlatform
            );  

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);

            customer.CustomerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
            customer.CustomerAddressInfo.CustomerAddressCollection.Should().HaveCount(1);

            DefaultFixture.CompareTwoCustomerAddressValues(
                customerAddressToRemove,
                removedCustomerAddress
            ).Should().BeTrue();
            DefaultFixture.CompareTwoCustomerAddressValues(
                removedCustomerAddress,
                customer.CustomerAddressInfo.CustomerAddressCollection.First()
            ).Should().BeFalse();
        }

        [Fact]
        public void Customer_Should_ChangeCustomerAddress()
        {
            // Arrange
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;
            var customerAddressType = CustomerAddressType.BusinessAddress;

            var customer = DefaultFixture.GenerateNewCustomer();
            var customerBeforeModification = customer.DeepClone();

            var newCustomerAddressValueObject1 = DefaultFixture.GenerateNewAddressValueObject();
            var newCustomerAddressValueObject2 = DefaultFixture.GenerateNewAddressValueObject();
            var addressValueObjectToChange = DefaultFixture.GenerateNewAddressValueObject();

            customer.AddNewCustomerAddress(CustomerAddressType.BusinessAddress, newCustomerAddressValueObject1, executionUser, sourcePlatform);
            customer.AddNewCustomerAddress(CustomerAddressType.BusinessAddress, newCustomerAddressValueObject2, executionUser, sourcePlatform);

            var firstCustomerAddress = customer.CustomerAddressInfo.CustomerAddressCollection.First().DeepClone();
            var customerAddressToChange = customer.CustomerAddressInfo.CustomerAddressCollection.Last();
            var customerAddressBeforeChange = customerAddressToChange.DeepClone();

            GenerateNewDateForDateTimeProvider();

            // Act
            var changedCustomerAddress = customer.ChangeCustomerAddress(
                customerAddressToChange.Id,
                customerAddressType,
                addressValueObjectToChange,
                executionUser,
                sourcePlatform
            );

            // Assert
            ValidateAfterRegisterModification(customerBeforeModification, customer, executionUser, sourcePlatform);

            customer.CustomerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
            customer.CustomerAddressInfo.CustomerAddressCollection.Should().HaveCount(2);

            DefaultFixture.CompareTwoCustomerAddressValues(
                firstCustomerAddress,
                customer.CustomerAddressInfo.CustomerAddressCollection.First()
            ).Should().BeTrue();
            customer.CustomerAddressInfo.CustomerAddressCollection.Where(q => q.Id == changedCustomerAddress.Id).Should().HaveCount(1);

            DefaultFixture.CompareTwoCustomerAddressValues(
                customerAddressBeforeChange,
                customer.CustomerAddressInfo.CustomerAddressCollection.First(q => q.Id == changedCustomerAddress.Id)
            ).Should().BeFalse();

            changedCustomerAddress.CustomerAddressType.Should().Be(customerAddressType);
            changedCustomerAddress.AddressValueObject.Should().Be(addressValueObjectToChange);
        }


        [Fact]
        public void Customer_Not_Should_ChangeCustomerAddress_When_Id_Not_Existing()
        {
            // Arrange
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;
            var customerAddressType = CustomerAddressType.BusinessAddress;

            var customer = DefaultFixture.GenerateNewCustomer();

            customer.AddNewCustomerAddress(
                CustomerAddressType.BusinessAddress,
                DefaultFixture.GenerateNewAddressValueObject(), 
                executionUser, 
                sourcePlatform
            );

            GenerateNewDateForDateTimeProvider();

            // Act
            var changedCustomerAddress = customer.ChangeCustomerAddress(
                Guid.NewGuid(),
                customerAddressType,
                DefaultFixture.GenerateNewAddressValueObject(),
                executionUser,
                sourcePlatform
            );

            // Assert
            changedCustomerAddress.Should().BeNull();
        }

    }
}
