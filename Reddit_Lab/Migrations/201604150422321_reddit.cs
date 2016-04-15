namespace Reddit_Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reddit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpVote = c.Int(nullable: false),
                        DownVote = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Link = c.String(),
                        Posted = c.DateTime(nullable: false),
                        Body = c.String(),
                        Comment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Posted = c.DateTime(nullable: false),
                        ParentPost_Id = c.Int(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.ParentPost_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.ParentPost_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ParentPost_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "ParentPost_Id" });
            DropIndex("dbo.Posts", new[] { "Comment_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
        }
    }
}
