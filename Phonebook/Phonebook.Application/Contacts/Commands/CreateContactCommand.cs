using MediatR;

namespace Phonebook.Application.Contacts.Commands;

public class CreateContactCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string JobTitle { get; set; } = "";
    public string? ProfileImagePath { get; set; } // For now, just a string
}