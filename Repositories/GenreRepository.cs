using MvcBookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcBookStore.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {

        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Genre> GetGenres()
        {
            return ApplicationDbContext.Genres.ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}