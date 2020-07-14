using MvcBookStore.Models;
using MvcBookStore.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcBookStore.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Random()
        {
            var book = new Book() { Name = "The Lord" };
            var customers = new List<Customer> {
                new Customer {  Name = "Customer 1" },
                new Customer {  Name = "Customer 2" }
            };

            var viewModel = new RandomViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}