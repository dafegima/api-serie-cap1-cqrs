namespace Domain.Interfaces.UseCases
{
	public interface IDeleteCustomerUseCase
	{
		Task Execute(string identification);
	}
}

