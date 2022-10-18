using MCB.Core.Infra.CrossCutting.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.Grpc.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IServiceCollection services)
    {
        var dependencyInjectionContainer = new DependencyInjectionContainer(services);

        Application.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.Entities.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
    }
}