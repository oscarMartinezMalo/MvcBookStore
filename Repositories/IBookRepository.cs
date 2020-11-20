using MvcBookStore.Models;
using System.Collections.Generic;

namespace MvcBookStore.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetDetails(int id);
        Book GetBookWithGenres(int id);
        IEnumerable<Book> GetBooksWithGenres();
        IEnumerable<Book> GetBooksWithGenresAvailables();
    }
}