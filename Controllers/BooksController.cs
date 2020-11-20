using MvcBookStore.Models;
using MvcBookStore.Persistence;
using MvcBookStore.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcBookStore.Controllers
{
    public class BooksController : Controller
    {
        //private ApplicationDbContext _context;
        public readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        //public BooksController()
        {
            //_context = new ApplicationDbContext();
            _unitOfWork = unitOfWork;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            //var genres = _context.Genres.ToList();
            var genres = _unitOfWork.Genres.GetGenres();
            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            //var books = _context.Books.SingleOrDefault(c => c.Id == id);
            var book = _unitOfWork.Books.Get(id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel(book)
            {
                //Genres = _context.Genres.ToList()
                Genres = _unitOfWork.Genres.GetGenres()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                BookFormViewModel viewModel = new BookFormViewModel(book)
                {
                    //Genres = _context.Genres.ToList()
                    Genres = _unitOfWork.Genres.GetGenres()
                };
                return View("New", viewModel);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                book.NumberAvailable = book.NumberInStock;
                //_context.Books.Add(book);
                _unitOfWork.Books.Add(book);
            }
            else
            {
                var bookInDb = _unitOfWork.Books.Get(book.Id);
                //var bookInDb = _context.Books.Single(m => m.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
            }

            _unitOfWork.Complete();
            //_context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ViewResult Index()
        {

            var books = _unitOfWork.Books.GetBooksWithGenres().ToList();
            //var books = _context.Books.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageBooks))
                return View("List", books);


            return View("ReadOnlyList", books);
        }

        public ActionResult Details(int id)
        {
            var oneBook = _unitOfWork.Books.GetBookWithGenres(id);
            //var oneBook = _context.Books.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (oneBook == null)
                return HttpNotFound();

            return View(oneBook);
        }
    }
}