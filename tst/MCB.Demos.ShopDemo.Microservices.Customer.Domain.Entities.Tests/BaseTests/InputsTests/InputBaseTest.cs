using FluentAssertions;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.Fixtures;
using MCB.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Tests.BaseTests.InputsTests
{
    [Collection(nameof(DefaultFixture))]
    public class InputBaseTest
        : TestBase
    {
        // Fields
        private readonly DefaultFixture _fixture;

        // Constructors
        public InputBaseTest(
            ITestOutputHelper testOutputHelper,
            DefaultFixture fixture
        ) : base(testOutputHelper)
        {
            _fixture = fixture;
        }

        [Fact]
        public void InputBase_Should_Correctly_initialized()
        {
            // Arrange
            var tenantId = _fixture.TenantId;
            var executionUser = _fixture.ExecutionUser;
            var sourcePlatform = _fixture.SourcePlatform;

            // Act
            var dummyInput = new DummyInput(tenantId, executionUser, sourcePlatform);

            // Assert
            dummyInput.Should().NotBeNull();
            dummyInput.TenantId.Should().Be(tenantId);
            dummyInput.ExecutionUser.Should().Be(executionUser);
            dummyInput.SourcePlatform.Should().Be(sourcePlatform);
        }

        public record DummyInput
            : InputBase
        {
            public DummyInput(
                Guid tenantId, 
                string executionUser, 
                string sourcePlatform
            ) : base(tenantId, executionUser, sourcePlatform)
            {
            }
        }
    }
}
