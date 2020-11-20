using System;

namespace MvcBookStore.Models
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public string BaseTableName { get; set; }
        public int BaseTablePK { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EventDateTime { get; set; }
        public AuditType AuditType { get; set; }
        public byte AuditTypeId { get; set; }
        public ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }
    }
}