using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Inputs.Base.Validators.Interfaces
{
    public interface IInputBaseValidator<TInputBase>
        : IValidator<TInputBase>
        where TInputBase : InputBase
    {
    }
}
