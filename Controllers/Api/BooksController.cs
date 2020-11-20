using AutoMapper;
using MvcBookStore.Dtos;
using MvcBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MvcBookStore.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var booksQuery = _context.Books
               .Include(m => m.Genre)
               .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(m => m.Name.Contains(query));

            var s = booksQuery.ToList();

            return booksQuery
                 .ToList()
                 .Select(Mapper.Map<Book, BookDto>);
        }
    }
}
