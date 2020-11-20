using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;


namespace MvcBookStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<AuditType> AuditTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            var changes = from e in this.ChangeTracker.Entries()
                          where e.State != EntityState.Unchanged
                          select e;

            foreach (var change in changes)
            {
                if (change.State == EntityState.Added)
                {
                    // Log Added
                }
                else if (change.State == EntityState.Modified)
                {
                    var item = change.Entity;
                    // Log Modified
                    //var item = change.Cast<IEntity>().Entity;
                    var originalValues = this.Entry(item).OriginalValues;
                    var currentValues = this.Entry(item).CurrentValues;

                    foreach (string propertyName in originalValues.PropertyNames)
                    {
                        var original = originalValues[propertyName];
                        var current = currentValues[propertyName];

                        if (!Equals(original, current))
                        {
                            // log propertyName: original --> current
                        }
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}