using System.Collections.Generic;

namespace MvcBookStore.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BooksIds { get; set; }
    }
}