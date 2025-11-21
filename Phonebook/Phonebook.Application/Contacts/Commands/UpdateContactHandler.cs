using MediatR;
using Phonebook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Application.Contacts.Commands;

public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, bool>
{
    private readonly PhonebookDbContext _context;

    public UpdateContactHandler(PhonebookDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (contact == null) return false;

        contact.FirstName = request.FirstName;
        contact.LastName = request.LastName;
        contact.PhoneNumber = request.PhoneNumber;
        contact.Email = request.Email;
        contact.JobTitle = request.JobTitle;
        contact.ProfileImagePath = request.ProfileImagePath;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}