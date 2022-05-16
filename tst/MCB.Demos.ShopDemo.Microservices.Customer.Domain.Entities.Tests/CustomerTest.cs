using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
