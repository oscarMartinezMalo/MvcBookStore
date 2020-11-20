using MvcBookStore.Models;
using System.Collections.Generic;

namespace MvcBookStore.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomerByName(string customerName);
        Customer GetCustomerWithMembershipType(int customerId);
        IEnumerable<Customer> GetAllCustomerWithMembershipType();
    }
}