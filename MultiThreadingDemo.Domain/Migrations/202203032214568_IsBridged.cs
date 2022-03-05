namespace MultiThreadingDemo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsBridged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "IsBridged", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "IsBridged", c => c.String());
        }
    }
}
