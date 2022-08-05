using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Enums;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.AddressValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.CustomerAddresses.Inputs
{
    public record RegisterNewCustomerAddressInput
        : InputBase
    {
        public CustomerAddressType CustomerAddressType { get; }
        public AddressValueObject AddressValueObject { get; }

        // Public Methods
        public RegisterNewCustomerAddressInput(
            Guid tenantId,
            CustomerAddressType customerAddressType,
            AddressValueObject addressValueObject,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            CustomerAddressType = customerAddressType;
            AddressValueObject = addressValueObject;
        }
    }
}
