using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Core.Infra.CrossCutting.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Specifications;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Validators;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects;
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
            return new CustomerAddress().RegisterNew(
                tenantId: existingTenantId ?? GenerateNewTenantId(),
                customerAddressType: existingCustomerAdressType ?? EnumUtils.GetRandomEnumValue<CustomerAddressType>(),
                addressValueObject: existingCustomerAddress ?? GenerateNewAddressValueObject(),
                executionUser: existingExecutionUser ?? GenerateNewExecutionUser(),
                sourcePlatform: existingSourcePlatform ?? GenerateNewSourcePlatform()
            );
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
            return new CustomerAddressInfo().RegisterNew(
                tenantId: existingTenantId ?? GenerateNewTenantId(),
                executionUser: existingExecutionUser ?? GenerateNewExecutionUser(),
                sourcePlatform: existingSourcePlatform ?? GenerateNewSourcePlatform()
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
                    new ChangeBirthDateInputShouldBeValidValidator(new CustomerSpecifications()),
                    new AddNewCustomerAddressInputShouldBeValidValidator(new CustomerAddressSpecifications())
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
