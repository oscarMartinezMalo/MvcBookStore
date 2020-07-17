using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBookStore.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //        [Min18YearsIfAMember]  Is remark because is create to use MVC action instead of API
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
    }
}