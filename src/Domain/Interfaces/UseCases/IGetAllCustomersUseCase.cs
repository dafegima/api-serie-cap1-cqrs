using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface IGetAllCustomersUseCase
	{
		Task<IEnumerable<Customer>> Execute();
	}
}