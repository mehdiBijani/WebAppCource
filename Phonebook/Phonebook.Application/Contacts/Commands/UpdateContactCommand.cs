using MediatR;

namespace Phonebook.Application.Contacts.Commands;

public class UpdateContactCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string JobTitle { get; set; } = "";
    public string? ProfileImagePath { get; set; }
}