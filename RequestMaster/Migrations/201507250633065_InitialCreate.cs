namespace RequestMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        ShortDescription = c.String(),
                        DetailsDescription = c.String(),
                        IsWarranty = c.Boolean(nullable: false),
                        ManufacturingFirm = c.String(),
                        ContactData = c.String(),
                        InitialDate = c.DateTime(nullable: false),
                        DeadlineRequest = c.DateTime(nullable: false),
                        State = c.String(),
                        MasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StateRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StateRequests");
            DropTable("dbo.Requests");
            DropTable("dbo.Categories");
        }
    }
}
