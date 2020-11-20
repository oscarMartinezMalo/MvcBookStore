using MvcBookStore.Models;
using MvcBookStore.Repositories;

namespace MvcBookStore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Books = new BookRepository(_context);
            Genres = new GenreRepository(_context);
            MembershipTypes = new MembershipTypeRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IBookRepository Books { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IMembershipTypeRepository MembershipTypes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}