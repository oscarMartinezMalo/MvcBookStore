using Microsoft.AspNet.Identity;
using MvcBookStore.Models;
using MvcBookStore.Persistence;
using MvcBookStore.ViewModels;
using System.Web.Mvc;

namespace MvcBookStore.Controllers
{
    public class CustomersController : Controller
    {
        //private ApplicationDbContext _context;
        public readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        //public CustomersController()
        {
            //_context = new ApplicationDbContext();
            _unitOfWork = unitOfWork;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            var membershipType = _unitOfWork.MembershipTypes.GetMembershipTypes();
            //var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _unitOfWork.MembershipTypes.GetMembershipTypes()
                    //MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                //_context.Customers.Add(customer);
                _unitOfWork.Customers.Add(customer);
            else
            {
                var customerInDb = _unitOfWork.Customers.Get(customer.Id);
                //var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            //_context.SaveChanges();
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _unitOfWork.Customers.Get(id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _unitOfWork.MembershipTypes.GetMembershipTypes()
                //MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks))
                return View("Index");

            return View("ReadOnlyList");  // You dont need to pass customers because you are going to get the customers from an AJAX request
        }

        public ActionResult Details(int id)
        {
            //Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            Customer customer = _unitOfWork.Customers.GetCustomerWithMembershipType(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}