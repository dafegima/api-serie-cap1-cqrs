using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases
{
    public class GetAllCustomersUseCase : IGetAllCustomersUseCase
    {
        private readonly ICustomersRepository _customersRepository;

        public GetAllCustomersUseCase(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public Task<IEnumerable<Customer>> Execute()
        {
            return _customersRepository.GetAll();
        }
    }
}