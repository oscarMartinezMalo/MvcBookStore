namespace MvcBookStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedAuditTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AuditTypes] (Id, Type, DateCreated) VALUES (1, N'Create', GETDATE())");
            Sql("INSERT INTO [dbo].[AuditTypes] (Id, Type, DateCreated) VALUES (2, N'Read', GETDATE())");
            Sql("INSERT INTO [dbo].[AuditTypes] (Id, Type, DateCreated) VALUES (3, N'Update', GETDATE())");
            Sql("INSERT INTO [dbo].[AuditTypes] (Id, Type, DateCreated) VALUES (4, N'Delete', GETDATE())");

        }

        public override void Down()
        {
        }
    }
}
