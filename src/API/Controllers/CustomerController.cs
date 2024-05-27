using Application.Customers.Create;
using Application.Customers.Delete;
using Application.Customers.GetAll;
using Application.Customers.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var query = new GetAllCustomersQuery();
        var result = await _mediator.Send(query);
        if (result.Any())
            return Ok(result);

        return NoContent();
    }

    [HttpGet("{identification}")]
    public async Task<IActionResult> GetById(string identification)
    {
        var query = new GetCustomerByIdQuery(identification);
        var result = await _mediator.Send(query);
        if (result is null || result == default)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        var result = await _mediator.Send(createCustomerCommand);
        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Error);
    }

    [HttpDelete("{identification}")]
    public async Task<IActionResult> DeleteCustomer(string identification)
    {
        var deletecustomerCommand = new DeleteCustomerCommand(identification);
        await _mediator.Send(deletecustomerCommand);
        return Ok();
    }
}