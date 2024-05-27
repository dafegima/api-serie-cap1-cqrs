namespace Application.Customers.GetAll
{
	public class GetAllCustomersQueryResponse
	{
        public GetAllCustomersQueryResponse(string identification, string firstName, string lastName, string email, DateTime birthDate)
        {
            Identification = identification;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

