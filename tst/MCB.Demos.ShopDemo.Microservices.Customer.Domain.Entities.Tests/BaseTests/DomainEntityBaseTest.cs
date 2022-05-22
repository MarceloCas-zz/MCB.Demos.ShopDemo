using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.BaseTests
{
    [Collection(nameof(DefaultFixture))]
    public class DomainEntityBaseTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public DomainEntityBaseTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DomainEntityBase_Should_Validate()
        {
            // Arrange
            var customer = new Customer();

            // Act
            var isValid = customer.Validate();

            // Assert
            customer.ValidationInfo.Should().NotBeNull();
            customer.ValidationInfo.HasValidationMessage.Should().BeTrue();
            customer.ValidationInfo.HasError.Should().BeTrue();
            isValid.Should().BeFalse();
            customer.ValidationInfo.IsValid.Should().Be(isValid);
            customer.ValidationInfo.ValidationMessageCollection.Should().NotBeNull();
            customer.ValidationInfo.ValidationMessageCollection.Should().HaveCount(3);

            var validationMessageCollection = customer.ValidationInfo.ValidationMessageCollection.ToList();

            validationMessageCollection[0].ValidationMessageType.Should().Be(ValidationMessageType.Error);
            validationMessageCollection[0].Code.Should().Be(Customer.ERROR_CODE);
            validationMessageCollection[0].Description.Should().Be(Customer.ERROR_DESCRIPTION);

            validationMessageCollection[1].ValidationMessageType.Should().Be(ValidationMessageType.Warning);
            validationMessageCollection[1].Code.Should().Be(Customer.WARNING_CODE);
            validationMessageCollection[1].Description.Should().Be(Customer.WARNING_DESCRIPTION);

            validationMessageCollection[2].ValidationMessageType.Should().Be(ValidationMessageType.Information);
            validationMessageCollection[2].Code.Should().Be(Customer.INFO_CODE);
            validationMessageCollection[2].Description.Should().Be(Customer.INFO_DESCRIPTION);
        }

        #region Models
        public class Customer
            : DomainEntityBase
        {
            // Constants
            public static readonly string ERROR_CODE = "code_1";
            public static readonly string ERROR_DESCRIPTION = "description_1";

            public static readonly string WARNING_CODE = "code_2";
            public static readonly string WARNING_DESCRIPTION = "description_2";

            public static readonly string INFO_CODE = "code_3";
            public static readonly string INFO_DESCRIPTION = "description_3";


            // Protected Methods
            protected override Core.Domain.Entities.DomainEntityBase CreateInstanceForCloneInternal() => new Customer();

            // Public Methods
            public bool Validate()
            {
                return Validate<Customer>(() =>
                    new ValidationResult(
                        new List<ValidationMessage> { 
                            new ValidationMessage(
                                validationMessageType: ValidationMessageType.Error,
                                code: ERROR_CODE,
                                description: ERROR_DESCRIPTION
                            ),
                            new ValidationMessage(
                                validationMessageType: ValidationMessageType.Warning,
                                code: WARNING_CODE,
                                description: WARNING_DESCRIPTION
                            ),
                            new ValidationMessage(
                                validationMessageType: ValidationMessageType.Information,
                                code: INFO_CODE,
                                description: INFO_DESCRIPTION
                            )
                        }
                    )
                );
            }
        }
        #endregion
    }
}
