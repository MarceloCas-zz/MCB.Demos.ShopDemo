using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Core.Infra.CrossCutting.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects.Specifications;
using MCB.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures
{
    [CollectionDefinition(nameof(DefaultFixture))]
    public class DefaultFixtureCollection
        : ICollectionFixture<DefaultFixture>
    {

    }

    public class DefaultFixture
        : FixtureBase
    {
        // Protected Methods
        protected override void ConfigureServices(ServiceCollection services)
        {

        }

        public static AddressValueObject GenerateNewAddressValueObject()
        {
            return new AddressValueObject(
                street: $"{nameof(AddressValueObject.Street)} {Guid.NewGuid()}",
                number: $"{nameof(AddressValueObject.Number)} {Guid.NewGuid()}",
                city: $"{nameof(AddressValueObject.City)} {Guid.NewGuid()}",
                state: $"{nameof(AddressValueObject.State)} {Guid.NewGuid()}",
                country: $"{nameof(AddressValueObject.Country)} {Guid.NewGuid()}",
                zipCode: $"{nameof(AddressValueObject.ZipCode)} {Guid.NewGuid()}"
            );
        }
        public static CustomerAddress GenerateNewCustomerAddress(
            Guid? existingTenantId = null,
            CustomerAddressType? existingCustomerAdressType = null,
            AddressValueObject? existingCustomerAddress = null,
            string existingExecutionUser = null,
            string existingSourcePlatform = null
        )
        {
            return new CustomerAddress(
                    new ChangeCustomerAddressTypeInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ChangeCustomerFullAddressInfoInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new RegisterNewCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications())
                ).RegisterNewCustomerAddress(new CustomerAddresses.Inputs.RegisterNewCustomerAddressInput(
                    tenantId: existingTenantId ?? GenerateNewTenantId(),
                    customerAddressType: existingCustomerAdressType ?? EnumUtils.GetRandomEnumValue<CustomerAddressType>(),
                    addressValueObject: existingCustomerAddress ?? GenerateNewAddressValueObject(),
                    executionUser: existingExecutionUser ?? GenerateNewExecutionUser(),
                    sourcePlatform: existingSourcePlatform ?? GenerateNewSourcePlatform()
                ));
        }
        public static bool CompareTwoCustomerAddressValues(
            CustomerAddress leftCustomerAddress,
            CustomerAddress rightCustomerAddress
        )
        {
            if (leftCustomerAddress is null && rightCustomerAddress is null)
                return true;
            if (leftCustomerAddress is null || rightCustomerAddress is null)
                return false;

            return leftCustomerAddress.Id == rightCustomerAddress.Id
                && leftCustomerAddress.TenantId == rightCustomerAddress.TenantId
                && leftCustomerAddress.AuditableInfo.Equals(rightCustomerAddress.AuditableInfo)
                && leftCustomerAddress.RegistryVersion == rightCustomerAddress.RegistryVersion
                && leftCustomerAddress.AddressValueObject.Equals(rightCustomerAddress.AddressValueObject)
                && leftCustomerAddress.CustomerAddressType == rightCustomerAddress.CustomerAddressType
                ;
        }
        public static CustomerAddressInfo GenerateNewCustomerAddressInfo(
            Guid? existingTenantId = null,
            string existingExecutionUser = null,
            string existingSourcePlatform = null
        )
        {
            return new CustomerAddressInfo(
                    customerAddressFactory: null,
                    registerNewCustomerAddressInputShouldBeValidFactory: null,
                    new RegisterNewCustomerAddressInfoInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ChangeDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new ClearDefaultCustomerAddressInfoShippingAddressInputShouldBeValidValidator(),
                    new AddNewCustomerAddressInfoCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications()),
                    new CustomerAddressInfoShouldHaveCustomerAddressValidator(new CustomerAddressInfoSpecifications()),
                    default,
                    default
                )
                .RegisterNewCustomerAddressInfo(new CustomerAddressesInfo.Inputs.RegisterNewCustomerAddressInfoInput(
                    tenantId: existingTenantId ?? GenerateNewTenantId(),
                    executionUser: existingExecutionUser ?? GenerateNewExecutionUser(),
                    sourcePlatform: existingSourcePlatform ?? GenerateNewSourcePlatform(),
                    customerAddressType: CustomerAddressType.HomeAddress,
                    addressValueObject: new AddressValueObject(),
                    isDefaultShippingAddress: true
                )
            );
        }
        public static Customers.Customer GenerateNewCustomer(
            Guid? existingTenantId = null,
            string existingFirstName = null,
            string existingLastName = null,
            DateOnly? existingBirthDate = null,
            string existingExecutionUser = null,
            string existingSourcePlatform = null
        )
        {
            return new Customers.Customer(
                    new RegisterNewCustomerInputShouldBeValidValidator(new CustomerSpecifications()),
                    new ChangeCustomerNameInputShouldBeValidValidator(new CustomerSpecifications()),
                    new ChangeCustomerBirthDateInputShouldBeValidValidator(new CustomerSpecifications()),
                    new AddNewCustomerAddressInputShouldBeValidValidator(
                        new CustomerAddressSpecifications(),
                        new AddressValueObjectSpecifications()
                    ),
                    default
                ).RegisterNewCustomer(
                    new Customers.Inputs.RegisterNewCustomerInput(
                        existingTenantId ?? GenerateNewTenantId(),
                        existingFirstName ?? Guid.NewGuid().ToString(),
                        existingLastName ?? Guid.NewGuid().ToString(),
                        existingBirthDate ?? DateOnly.FromDateTime(DateTimeProvider.GetDate().DateTime),
                        existingExecutionUser ?? GenerateNewExecutionUser(),
                        existingSourcePlatform ?? GenerateNewSourcePlatform()
                    )
                );
        }
    }
}
