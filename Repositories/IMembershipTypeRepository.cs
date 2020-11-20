using MvcBookStore.Models;
using System.Collections.Generic;

namespace MvcBookStore.Repositories
{
    public interface IMembershipTypeRepository
    {
        ApplicationDbContext ApplicationDbContext { get; }

        IEnumerable<MembershipType> GetMembershipTypes();
    }
}