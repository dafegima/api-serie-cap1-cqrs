using System.Text;
using System.Text.RegularExpressions;
using Application.Commons;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;

namespace Application.Customers.Create
{
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CreateCustomerCommandResponse>>
	{
        private readonly ICreateCustomerUseCase _createCustomerUseCase;

        public CreateCustomerCommandHandler(ICreateCustomerUseCase createCustomerUseCase)
        {
            _createCustomerUseCase = createCustomerUseCase;
        }

        public async Task<Result<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            StringBuilder errors;
            if (ModelIsValid(request, out errors))
            {
                var customer = new Customer(request.Identification, request.FirstName, request.LastName, request.Email, request.BirthDate);
                var result = await _createCustomerUseCase.Execute(customer);
                return Result<CreateCustomerCommandResponse>.Success(MapToResponse(result));
            }

            return Result<CreateCustomerCommandResponse>.Failure(errors.ToString());
        }

        private bool ModelIsValid(CreateCustomerCommand createCustomerCommand, out StringBuilder errors)
        {
            errors = new StringBuilder();

            if (string.IsNullOrEmpty(createCustomerCommand.FirstName))
                errors.Append("First Name must not be empty.\n");

            if (string.IsNullOrEmpty(createCustomerCommand.LastName))
                errors.Append("Last Name must not be empty.\n");

            if (string.IsNullOrEmpty(createCustomerCommand.Identification))
                errors.Append("Identification must not be empty.\n");

            if (string.IsNullOrEmpty(createCustomerCommand.Email))
                errors.Append("Email must not be empty.\n");

            if (!Regex.IsMatch(createCustomerCommand.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                errors.Append("Email is not in the correct format..\n");

            return errors.Length == 0;
        }

        private CreateCustomerCommandResponse MapToResponse(Customer customer)
        {
            return new CreateCustomerCommandResponse(customer.Identification, customer.FirstName, customer.LastName, customer.Email, customer.BirthDate);
        }
    }
}