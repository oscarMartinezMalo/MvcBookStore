using MvcBookStore.Repositories;
using System;

namespace MvcBookStore.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IBookRepository Books { get; }
        IGenreRepository Genres { get; }
        IMembershipTypeRepository MembershipTypes { get; }

        int Complete();
    }
}