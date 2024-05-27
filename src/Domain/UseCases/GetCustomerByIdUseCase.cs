using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerByIdUseCase(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customer> Execute(string identification)
        {
            var result = await _customersRepository.GetById(identification);
            return result;
        }
    }
}

