using MCB.Core.Infra.CrossCutting.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Enums;
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
        // Properties
        public Guid TenantId { get; }
        public string ExecutionUser { get; }
        public string SourcePlatform { get; }

        // Constructors
        public DefaultFixture()
        {
            TenantId = GenerateNewTenantId();
            ExecutionUser = GenerateNewExecutionUser();
            SourcePlatform = GenerateNewSourcePlatform();
        }

        // Protected Methods
        protected override void ConfigureServices(ServiceCollection services)
        {

        }

        // Public Methods
        public static Guid GenerateNewTenantId() => Guid.NewGuid();
        public static string GenerateNewExecutionUser() => $"{nameof(ExecutionUser)} {Guid.NewGuid()}";
        public static string GenerateNewSourcePlatform() => $"{nameof(SourcePlatform)} {Guid.NewGuid()}";
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
    }
}
