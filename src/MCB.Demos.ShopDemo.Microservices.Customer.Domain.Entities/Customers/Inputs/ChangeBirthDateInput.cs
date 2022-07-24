using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs
{
    public class ChangeBirthDateInput
        : InputBase
    {
        public string FirstName { get; }
        public string LastName { get; }

        public ChangeBirthDateInput(
            Guid tenantId,
            string firstName,
            string lastName,
            string executionUser,
            string sourcePlatform
        ) : base(tenantId, executionUser, sourcePlatform)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
