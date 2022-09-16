using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.CustomersTests;

[Collection(nameof(DefaultFixture))]
public class CustomerAddressInfoTest
    : TestBase
{
    // Fields
    private readonly DefaultFixture _fixture;

    // Constructors
    public CustomerAddressInfoTest(
        ITestOutputHelper testOutputHelper,
        DefaultFixture fixture
    ) : base(testOutputHelper)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CustomerAddressInfo_Should_Correctly_Instanciated()
    {
        // Arrange and Act
        var customerAddressInfo = new CustomerAddressInfo(
            customerAddressFactory: null,
            registerNewCustomerAddressInputShouldBeValidFactory: null,
            registerNewCustomerAddressInfoInputShouldBeValidValidator: null,
            changeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator: null,
            clearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator: null,
            addNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator: null,
            customerAddressInfoShouldHaveCustomerAddressValidator: null,
            removeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator: null,
            changeCustomerAddressInfoCustomerAddressInputShouldBeValidValidator: null
        );

        // Assert
        customerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
        customerAddressInfo.CustomerAddressCollection.Should().HaveCount(0);
        customerAddressInfo.DefaultShippingAddress.Should().BeNull();
    }

    [Fact]
    public void CustomerAddressInfo_Should_RegisterNew()
    {
        // Arrange and Act
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );

        // Assert
        ValidateAfterRegisterNew(customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_ChangeDefaultShippingAddress()
    {
        // Arrange
        var customerAddress = DefaultFixture.GenerateNewCustomerAddress();
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        var clonedCustomerAddressInfoAfterRegisterNew = customerAddressInfo.DeepClone();
        GenerateNewDateForDateTimeProvider();

        // Act
        customerAddressInfo.ChangeDefaultCustomerAddressInfoShippingAddress(new CustomerAddressesInfo.Inputs.ChangeDefaultCustomerAddressInfoShippingAddressInput(
            _fixture.TenantId,
            customerAddress.Id,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        customerAddressInfo.DefaultShippingAddress.Should().NotBeNull();
        customerAddressInfo.DefaultShippingAddress.Should().NotBeSameAs(customerAddress);
        DefaultFixture.CompareTwoCustomerAddressValues(customerAddressInfo.DefaultShippingAddress, customerAddress).Should().BeTrue();
        ValidateAfterRegisterModification(clonedCustomerAddressInfoAfterRegisterNew, customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_ClearDefaultShippingAddress()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        var customerAddress = DefaultFixture.GenerateNewCustomerAddress();
        customerAddressInfo.ChangeDefaultCustomerAddressInfoShippingAddress(new CustomerAddressesInfo.Inputs.ChangeDefaultCustomerAddressInfoShippingAddressInput(
            _fixture.TenantId,
            customerAddress.Id,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        var clonedCustomerAddressInfoAfterRegisterNew = customerAddressInfo.DeepClone();
        GenerateNewDateForDateTimeProvider();

        // Act
        customerAddressInfo.ClearDefaultCustomerAddressInfoShippingAddress(new CustomerAddressesInfo.Inputs.ClearDefaultCustomerAddressInfoShippingAddressInput(
            _fixture.TenantId,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        customerAddressInfo.DefaultShippingAddress.Should().BeNull();
        ValidateAfterRegisterModification(clonedCustomerAddressInfoAfterRegisterNew, customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_AddNewCustomerAddress()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        var clonedCustomerAddressInfoAfterRegisterNew = customerAddressInfo.DeepClone();
        GenerateNewDateForDateTimeProvider();

        var customerAddressType = CustomerAddressType.HomeAddress;
        var addressValueObject = DefaultFixture.GenerateNewAddressValueObject();

        // Act
        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            tenantId: _fixture.TenantId,
            customerAddressType,
            addressValueObject,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        customerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
        customerAddressInfo.CustomerAddressCollection.Should().HaveCount(1);

        var customerAddressArray = customerAddressInfo.CustomerAddressCollection.ToArray();
        customerAddressArray[0].CustomerAddressType.Should().Be(customerAddressType);
        customerAddressArray[0].AddressValueObject.Should().NotBeSameAs(addressValueObject);
        customerAddressArray[0].AddressValueObject.Should().Be(addressValueObject);
        ValidateAfterRegisterNew(customerAddressArray[0], _fixture.ExecutionUser, _fixture.SourcePlatform);

        customerAddressInfo.CustomerAddressCollection.Should().NotBeSameAs(customerAddressInfo.CustomerAddressCollection);

        ValidateAfterRegisterModification(clonedCustomerAddressInfoAfterRegisterNew, customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_RemoveCustomerAddress()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            tenantId: _fixture.TenantId,
            customerAddressType: CustomerAddressType.HomeAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.BusinessAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();

        var clonedCustomerAddressInfoAfterRegisterNew = customerAddressInfo.DeepClone();

        // Act
        customerAddressInfo.RemoveCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.RemoveCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressInfo.CustomerAddressCollection.First().Id,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        customerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
        customerAddressInfo.CustomerAddressCollection.Should().HaveCount(1);

        var customerAddressArray = customerAddressInfo.CustomerAddressCollection.ToArray();
        customerAddressArray[0].CustomerAddressType.Should().Be(CustomerAddressType.BusinessAddress);

        customerAddressInfo.CustomerAddressCollection.Should().NotBeSameAs(customerAddressInfo.CustomerAddressCollection);

        ValidateAfterRegisterModification(clonedCustomerAddressInfoAfterRegisterNew, customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_Not_RemoveCustomerAddress()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.HomeAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();

        // Act
        var removedCustomerAddress = customerAddressInfo.RemoveCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.RemoveCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressId: Guid.NewGuid(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        removedCustomerAddress.Should().BeNull();
    }

    [Fact]
    public void CustomerAddressInfo_Should_ChangeCustomerAddress()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.HomeAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();
        var firstCustomerAddress = customerAddressInfo.CustomerAddressCollection.First();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.BusinessAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();

        var clonedCustomerAddressInfoAfterRegisterNew = customerAddressInfo.DeepClone();
        var clonedCustomerAddressAfterFirstModification = customerAddressInfo.CustomerAddressCollection.Last().DeepClone();
        var customerAddressToModify = customerAddressInfo.CustomerAddressCollection.Last();

        // Act
        customerAddressInfo.ChangeCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.ChangeCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressToModify.Id,
            CustomerAddressType.HomeAddress,
            customerAddressToModify.AddressValueObject,
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        customerAddressInfo.CustomerAddressCollection.Should().NotBeNull();
        customerAddressInfo.CustomerAddressCollection.Should().HaveCount(2);
        customerAddressInfo.CustomerAddressCollection.Select(q => q.CustomerAddressType == CustomerAddressType.HomeAddress).Should().HaveCount(2);

        var customerAddressArray = customerAddressInfo.CustomerAddressCollection.ToArray();
        DefaultFixture.CompareTwoCustomerAddressValues(firstCustomerAddress, customerAddressArray[0]);
        ValidateAfterRegisterModification(clonedCustomerAddressAfterFirstModification, customerAddressArray[1], _fixture.ExecutionUser, _fixture.SourcePlatform);

        ValidateAfterRegisterModification(clonedCustomerAddressInfoAfterRegisterNew, customerAddressInfo, _fixture.ExecutionUser, _fixture.SourcePlatform);
    }

    [Fact]
    public void CustomerAddressInfo_Should_Not_ChangeCustomerAddress_When_Id_Not_Found()
    {
        // Arrange
        var customerAddressInfo = DefaultFixture.GenerateNewCustomerAddressInfo(
            existingTenantId: _fixture.TenantId,
            existingExecutionUser: _fixture.ExecutionUser,
            existingSourcePlatform: _fixture.SourcePlatform
        );
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.HomeAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();

        customerAddressInfo.AddNewCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.AddNewCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            customerAddressType: CustomerAddressType.BusinessAddress,
            addressValueObject: DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));
        GenerateNewDateForDateTimeProvider();


        // Act
        var changedCustomerAddress = customerAddressInfo.ChangeCustomerAddressInfoCustomerAddress(new CustomerAddressesInfo.Inputs.ChangeCustomerAddressInfoCustomerAddressInput(
            _fixture.TenantId,
            Guid.NewGuid(),
            CustomerAddressType.HomeAddress,
            DefaultFixture.GenerateNewAddressValueObject(),
            _fixture.ExecutionUser,
            _fixture.SourcePlatform
        ));

        // Assert
        changedCustomerAddress.Should().BeNull();
    }
}
