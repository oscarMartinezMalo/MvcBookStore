using MvcBookStore.Models;
using System.Collections.Generic;

namespace MvcBookStore.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}