namespace MultiThreadingDemo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectiveInformationJson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "CollectiveInformationJson", c => c.String());
            DropColumn("dbo.UserComments", "JsonData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserComments", "JsonData", c => c.String());
            DropColumn("dbo.UserComments", "CollectiveInformationJson");
        }
    }
}
