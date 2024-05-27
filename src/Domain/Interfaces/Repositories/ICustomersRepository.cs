using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface ICustomersRepository
	{
		Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(string identification);
		Task<Customer> Add(Customer customer);
		Task Delete(string identification);
    }
}