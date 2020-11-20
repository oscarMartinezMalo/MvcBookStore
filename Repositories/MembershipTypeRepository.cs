using MvcBookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcBookStore.Repositories
{
    public class MembershipTypeRepository : Repository<MembershipType>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return ApplicationDbContext.MembershipTypes.ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}