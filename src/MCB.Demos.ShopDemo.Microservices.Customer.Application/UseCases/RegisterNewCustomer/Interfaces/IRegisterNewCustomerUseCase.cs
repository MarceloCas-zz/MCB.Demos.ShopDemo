using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;

public interface IRegisterNewCustomerUseCase
    : IUseCase<RegisterNewCustomerUseCaseInput>
{
}