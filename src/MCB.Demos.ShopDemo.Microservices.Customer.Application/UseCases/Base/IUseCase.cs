using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base.Input;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;

public interface IUseCase<TInput>
    where TInput : UseCaseInputBase
{

}