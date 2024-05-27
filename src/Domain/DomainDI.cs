using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DomainDI
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddTransient<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddTransient<IDeleteCustomerUseCase, DeleteCustomerUseCase>();
        services.AddTransient<IGetAllCustomersUseCase, GetAllCustomersUseCase>();
        services.AddTransient<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
        return services;
    }
}