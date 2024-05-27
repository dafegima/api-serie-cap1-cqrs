using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface ICreateCustomerUseCase
	{
		Task<Customer> Execute(Customer customer);
	}
}