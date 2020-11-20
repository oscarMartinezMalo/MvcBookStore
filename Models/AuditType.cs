using System;

namespace MvcBookStore.Models
{
    public class AuditType
    {
        public byte Id { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}