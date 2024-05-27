using Application.Commons;
using MediatR;

namespace Application.Customers.Delete
{
	public class DeleteCustomerCommand : IRequest
	{
        public DeleteCustomerCommand(string identification)
        {
            Identification = identification;
        }

        public string Identification { get; set; }
    }
}

