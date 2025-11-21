using MediatR;
using Phonebook.Domain.Entities;

namespace Phonebook.Application.Contacts.Queries;

public class GetAllContactsQuery : IRequest<List<Contact>>
{
}