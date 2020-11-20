using MvcBookStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBookStore.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Book GetDetails(int id)
        {
            return ApplicationDbContext.Books.SingleOrDefault(m => m.Id == id);
        }

        public Book GetBookWithGenres(int id)
        {
            return ApplicationDbContext.Books.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Book> GetBooksWithGenres()
        {
            return ApplicationDbContext.Books.Include(m => m.Genre);
        }

        public IEnumerable<Book> GetBooksWithGenresAvailables()
        {
            return ApplicationDbContext.Books
                .Include(m => m.Genre)
               .Where(m => m.NumberAvailable > 0);
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}