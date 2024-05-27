using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Customers.GetById
{
	public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse?>
	{
        private readonly IGetCustomerByIdUseCase _getCustomerByIdUseCase;

        public GetCustomerByIdQueryHandler(IGetCustomerByIdUseCase getCustomerByIdUseCase)
        {
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        public async Task<GetCustomerByIdQueryResponse?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getCustomerByIdUseCase.Execute(request.Identification);
            return MapToResponse(result);
        }

        private GetCustomerByIdQueryResponse? MapToResponse(Customer customer)
        {
            if (customer is not null)
                return new GetCustomerByIdQueryResponse(customer.Identification, customer.FirstName, customer.LastName, customer.Email, customer.BirthDate);

            return default;
        }
    }
}

