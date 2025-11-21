using MediatR;
using Phonebook.Domain.Entities;

namespace Phonebook.Application.Contacts.Queries;

public class SearchContactsQuery : IRequest<List<Contact>>
{
    public string SearchText { get; set; } = string.Empty;
}