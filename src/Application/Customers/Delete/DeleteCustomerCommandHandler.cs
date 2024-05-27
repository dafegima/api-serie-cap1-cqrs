using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Customers.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IDeleteCustomerUseCase _deleteCustomerUseCase;

        public DeleteCustomerCommandHandler(IDeleteCustomerUseCase deleteCustomerUseCase)
        {
            _deleteCustomerUseCase = deleteCustomerUseCase;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _deleteCustomerUseCase.Execute(request.Identification);
        }
    }
}