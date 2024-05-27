using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomersRepository _customersRepository;

        public CreateCustomerUseCase(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customer> Execute(Customer customer)
        {
            var result = await _customersRepository.Add(customer);
            return result;
        }
    }
}