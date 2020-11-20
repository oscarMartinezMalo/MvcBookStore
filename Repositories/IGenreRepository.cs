using MvcBookStore.Models;
using System.Collections.Generic;

namespace MvcBookStore.Repositories
{
    public interface IGenreRepository
    {
        ApplicationDbContext ApplicationDbContext { get; }

        IEnumerable<Genre> GetGenres();
    }
}