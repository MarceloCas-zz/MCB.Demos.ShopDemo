using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddressesInfo.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using MCB.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.CustomerAddressesTests.FactoriesTests
{
    [Collection(nameof(DefaultFixture))]
    public class ChangeCustomerFullAddressInfoInputFactoryTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _defaultFixture;

        // Constructors
        public ChangeCustomerFullAddressInfoInputFactoryTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture defaultFixture
        ) : base(testOutputHelper)
        {
            _defaultFixture = defaultFixture;
        }

        // Protected Methods
        protected override IDateTimeProvider CreateDateTimeProvider(DateTimeOffset currentDate)
        {
            var dateTimeProvider = new DateTimeProvider();

            dateTimeProvider.ChangeGetDateCustomFunction(
                () => new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 12, minute: 0, second: 0, offset: TimeSpan.Zero)
            );

            return dateTimeProvider;
        }

        // Public Methods
        [Fact]
        public void ChangeCustomerFullAddressInfoInputFactory_Should_Create_New_ChangeCustomerFullAddressInfoInput()
        {
            // Arrange
            var dependencyInjectionContainer = _defaultFixture.CreateNewDependencyInjectionContainer();
            var changeCustomerFullAddressInfoInputFactory = dependencyInjectionContainer.Resolve<IChangeCustomerFullAddressInfoInputFactory>();

            var changeCustomerAddressInfoCustomerAddressInput = new ChangeCustomerAddressInfoCustomerAddressInput(
                tenantId: _defaultFixture.TenantId,
                customerAddressId: Guid.NewGuid(),
                customerAddressType: CustomerAddressType.BusinessAddress,
                addressValueObject: _defaultFixture.CreateDefaultAddressValueObject(),
                executionUser: _defaultFixture.ExecutionUser,
                sourcePlatform: _defaultFixture.SourcePlatform
            );

            // Act
            var changeCustomerFullAddressInfoInput = changeCustomerFullAddressInfoInputFactory.Create(changeCustomerAddressInfoCustomerAddressInput);

            // Assert
            DefaultFixture.InputBaseShouldHaveSameValues(changeCustomerFullAddressInfoInput, changeCustomerAddressInfoCustomerAddressInput);
            changeCustomerFullAddressInfoInput.AddressValueObject.Should().Be(changeCustomerAddressInfoCustomerAddressInput.AddressValueObject);
            changeCustomerFullAddressInfoInput.CustomerAddressType.Should().Be(changeCustomerAddressInfoCustomerAddressInput.CustomerAddressType);
        }
    }
}
