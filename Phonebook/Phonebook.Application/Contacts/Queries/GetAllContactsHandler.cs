using MediatR;
using Phonebook.Infrastructure.Persistence;
using Phonebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Application.Contacts.Queries;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
{
    private readonly PhonebookDbContext _context;

    public GetAllContactsHandler(PhonebookDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contacts.ToListAsync(cancellationToken);
    }
}