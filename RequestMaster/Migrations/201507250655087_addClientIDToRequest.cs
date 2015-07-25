namespace RequestMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientIDToRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ClientID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "ClientID");
        }
    }
}
