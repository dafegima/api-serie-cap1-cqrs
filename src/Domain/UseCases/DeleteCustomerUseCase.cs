using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class DeleteCustomerUseCase : IDeleteCustomerUseCase
    {
        private readonly ICustomersRepository _customersRepository;
        public DeleteCustomerUseCase(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task Execute(string identification)
        {
            await _customersRepository.Delete(identification);
        }
    }
}