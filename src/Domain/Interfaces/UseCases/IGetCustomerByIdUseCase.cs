using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface IGetCustomerByIdUseCase
	{
		Task<Customer> Execute(string identification);
	}
}