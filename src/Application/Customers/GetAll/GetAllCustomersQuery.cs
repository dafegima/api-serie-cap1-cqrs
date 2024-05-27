using MediatR;

namespace Application.Customers.GetAll
{
	public class GetAllCustomersQuery : IRequest<IEnumerable<GetAllCustomersQueryResponse>>
    {
	}
}