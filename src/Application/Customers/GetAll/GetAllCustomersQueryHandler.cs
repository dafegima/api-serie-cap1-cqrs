using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Customers.GetAll
{
	public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<GetAllCustomersQueryResponse>>
	{
        private readonly IGetAllCustomersUseCase _getAllCustomersUseCase;

        public GetAllCustomersQueryHandler(IGetAllCustomersUseCase getAllCustomersUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
        }

        public async Task<IEnumerable<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAllCustomersUseCase.Execute();
            
            var response = MapToResponse(result);
            
            return response;
        }

        private List<GetAllCustomersQueryResponse> MapToResponse(IEnumerable<Customer> result)
        {
            List<GetAllCustomersQueryResponse> response = new();
            foreach (var item in result)
                response.Add(CreateCustomerRow(item));

            return response;
        }

        private GetAllCustomersQueryResponse CreateCustomerRow(Customer customer)
        {
            return new GetAllCustomersQueryResponse(customer.Identification, customer.FirstName, customer.LastName, customer.Email, customer.BirthDate);
        }
    }
}

