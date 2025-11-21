using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Application.Contacts.Commands;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly PhonebookDbContext _context;

    public CreateContactHandler(PhonebookDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            JobTitle = request.JobTitle,
            ProfileImagePath = request.ProfileImagePath
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}