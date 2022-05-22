
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base
{
    public abstract class DomainEntityBase
        : Core.Domain.Entities.DomainEntityBase
    {
        protected bool Validate<TDomainEntityBase>(Func<ValidationResult> handle)
            where TDomainEntityBase : DomainEntityBase
        {
            foreach (var validationMessage in handle().ValidationMessageCollection)
                AddValidationMessageInternal<TDomainEntityBase>(
                    validationMessage.ValidationMessageType,
                    validationMessage.Code,
                    validationMessage.Description
                );

            return ValidationInfo.IsValid;
        }
    }
}
