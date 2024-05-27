using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
	public class CustomersRepository : ICustomersRepository
    {
        private List<Customer> _customers;

		public CustomersRepository()
		{
            _customers = new List<Customer>();
		}

        public async Task<Customer> Add(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }

        public async Task Delete(string identification)
        {
            _customers.Remove(_customers.FirstOrDefault(x=> x.Identification == identification));
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return _customers;
        }

        public async Task<Customer> GetById(string identification)
        {
            return _customers.FirstOrDefault(x => x.Identification == identification)!;
        }
    }
}

