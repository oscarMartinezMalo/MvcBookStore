using MvcBookStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBookStore.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetCustomerByName(string customerName)
        {
            return ApplicationDbContext.Customers.Where(c => c.Name == customerName).ToList();
        }

        public Customer GetCustomerWithMembershipType(int customerId)
        {
            return ApplicationDbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == customerId);
        }

        public IEnumerable<Customer> GetAllCustomerWithMembershipType()
        {
            return ApplicationDbContext.Customers.Include(c => c.MembershipType);
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}