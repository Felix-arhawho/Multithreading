namespace MultiThreadingDemo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserComments", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserComments", "UserId", c => c.String());
        }
    }
}
