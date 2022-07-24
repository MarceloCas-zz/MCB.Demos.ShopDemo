﻿using MCB.Core.Domain.Entities.DomainEntitiesBase.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public record ChangeBirthDateInput
        : InputBase
    {
        public DateOnly BirthDate { get; }

        public ChangeBirthDateInput(
            Guid tenantId,
            DateOnly birthDate,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            BirthDate = birthDate;
        }
    }
}
