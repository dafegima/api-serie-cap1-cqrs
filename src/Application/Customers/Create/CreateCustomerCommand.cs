using Application.Commons;
using MediatR;

namespace Application.Customers.Create
{
	public class CreateCustomerCommand : IRequest<Result<CreateCustomerCommandResponse>>
	{
		public string Identification { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
	}
}