using MediatR;
using Microsoft.EntityFrameworkCore;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Application.Contacts.Queries;

public class SearchContactsHandler : IRequestHandler<SearchContactsQuery, List<Contact>>
{
    private readonly PhonebookDbContext _context;
    public SearchContactsHandler(PhonebookDbContext context) => _context = context;

    public async Task<List<Contact>> Handle(SearchContactsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(c => c.FirstName.Contains(request.SearchText) ||
                        c.LastName.Contains(request.SearchText) ||
                        c.PhoneNumber.Contains(request.SearchText) ||
                        c.JobTitle.Contains(request.SearchText))
            .ToListAsync(cancellationToken);
    }
}