namespace MvcBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditTrail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTrails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseTableName = c.String(),
                        BaseTablePK = c.Int(nullable: false),
                        FieldName = c.String(),
                        OldValue = c.String(),
                        NewValue = c.String(),
                        EventDateTime = c.DateTime(nullable: false),
                        AuditTypeId = c.Byte(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditTypes", t => t.AuditTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.AuditTypeId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AuditTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditTrails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuditTrails", "AuditTypeId", "dbo.AuditTypes");
            DropIndex("dbo.AuditTrails", new[] { "ApplicationUserId" });
            DropIndex("dbo.AuditTrails", new[] { "AuditTypeId" });
            DropTable("dbo.AuditTypes");
            DropTable("dbo.AuditTrails");
        }
    }
}
