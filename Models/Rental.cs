using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBookStore.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateTime { get; set; }
    }
}