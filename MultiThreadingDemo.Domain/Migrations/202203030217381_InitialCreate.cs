namespace MultiThreadingDemo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Body = c.String(),
                        HasGeneratedUserDetail = c.Boolean(nullable: false, defaultValue: false),
                        IsBridged = c.Boolean(nullable: false, defaultValue: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        JsonData = c.String(),
                        DateGenerated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        DateGenerated = c.String(),
                        IsBridged = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
            DropTable("dbo.UserComments");
            DropTable("dbo.Comments");
        }
    }
}
