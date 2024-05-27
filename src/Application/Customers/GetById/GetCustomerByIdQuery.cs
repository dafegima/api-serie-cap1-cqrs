using Application.Commons;
using MediatR;

namespace Application.Customers.GetById
{
	public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResponse?>
	{
        public GetCustomerByIdQuery(string identification)
        {
            Identification = identification;
        }

        public string Identification { get; set; }
	}
}