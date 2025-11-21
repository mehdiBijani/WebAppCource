using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Contacts.Commands;
using Phonebook.Application.Contacts.Queries;

namespace Phonebook.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateContactCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _mediator.Send(new GetAllContactsQuery());
        return Ok(contacts);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateContactCommand command)
    {
        if (id != command.Id) return BadRequest("Id mismatch");

        var result = await _mediator.Send(command);
        return result ? Ok("Updated") : NotFound();
    }
}